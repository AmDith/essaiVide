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
            ViewBag => Recup�rer le m�me type
            ViewData => Dictionnaire durant une requ�te C => V | V => C
            TempData => Dictionnaire durant des requ�tes successives
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
                TempData["Message"] = "Client cr�� avec succ�s!";
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
                // 1. Rechercher l'utilisateur avec le r�le "Secr�taire"
                var secretaire = await _userService.GetUserByRoleAsync("Secretaire");

                if (secretaire == null)
                {
                    TempData["Error"] = "Aucun utilisateur avec le r�le de Secr�taire trouv�.";
                    return RedirectToAction("IndexCommande");
                }

                // 2. R�cup�rer les commandes du client
                var commandes = await _clientService.GetCommandesByClientAsync(commandeIds);

                if (commandes == null || !commandes.Any())
                {
                    TempData["Error"] = "Aucune commande valide trouv�e.";
                    return RedirectToAction("IndexCommande");
                }

                // 3. Ajouter les commandes � la liste des commandes de la secr�taire
                await _userService.AjouterCommandesAUserAsync(secretaire.Id, commandes);

                // 4. Informer l'utilisateur que l'op�ration a r�ussi
                TempData["Message"] = "Les commandes ont �t� envoy�es � la secr�taire avec succ�s !";
                return RedirectToAction("IndexCommande");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de l'envoi des commandes � la secr�taire.");
                TempData["Error"] = "Une erreur est survenue lors de l'envoi des commandes.";
                return RedirectToAction("IndexCommande");
            }
        }

    }
