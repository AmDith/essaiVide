using System.Diagnostics;
using Application.Models;
using Application.Services;
using essaiVide.Models;
using Microsoft.AspNetCore.Mvc;

namespace essaiVide.Controllers;

    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;
        private readonly IUserService _userService;


        /* 
            ViewBag => Recupérer le même type
            ViewData => Dictionnaire durant une requête C => V | V => C
            TempData => Dictionnaire durant des requêtes successives
         */

        public ClientController(ILogger<ClientController> logger, IClientService clientService, IUserService userService)
        {
            _logger = logger;
            _clientService = clientService;
            _userService = userService;
        }
        // Home/Index | Routes
        public async Task<IActionResult> IndexCommmande()
        {
            var id = 2;
            // Fetch clients from the service
            var clients = await _clientService.GetCommandesByClientAsync(id);
            // Pass the clients to the view
            return View(clients);
        }

        public async Task<IActionResult> IndexPaiement()
        {
            var id = 3;
            // Fetch clients from the service
            var clients = await _clientService.GetPaiementsByClientAsync(id);
            // Pass the clients to the view
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Prenom,Telephone,Adresse,Solde")] Client client)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine($"***********************************************{client.Adresse}***********************************************");
                var clientAdded = await _clientService.Create(client);
                // if (clientAdded != null)
                // {
                TempData["Message"] = "Client créé avec succès!";
                return RedirectToAction(nameof(Index));
                // }
            }
            return View(client);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    

    [HttpPost]
        public async Task<IActionResult> EnvoyerCommandesASecretaire(int clientId, int commandeIds)
        {
            try
            {
                // 1. Rechercher l'utilisateur avec le rôle "Secrétaire"
                var secretaire = await _userService.GetUserByRoleAsync("Secretaire");

                if (secretaire == null)
                {
                    TempData["Error"] = "Aucun utilisateur avec le rôle de Secrétaire trouvé.";
                    return RedirectToAction("IndexCommande");
                }

                // 2. Récupérer les commandes du client
                var commandes = await _clientService.GetCommandesByClientAsync(commandeIds);

                if (commandes == null || !commandes.Any())
                {
                    TempData["Error"] = "Aucune commande valide trouvée.";
                    return RedirectToAction("IndexCommande");
                }

                // 3. Ajouter les commandes à la liste des commandes de la secrétaire
                await _userService.AjouterCommandesAUserAsync(secretaire.Id, commandes);

                // 4. Informer l'utilisateur que l'opération a réussi
                TempData["Message"] = "Les commandes ont été envoyées à la secrétaire avec succès !";
                return RedirectToAction("IndexCommande");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de l'envoi des commandes à la secrétaire.");
                TempData["Error"] = "Une erreur est survenue lors de l'envoi des commandes.";
                return RedirectToAction("IndexCommande");
            }
        }

    }
