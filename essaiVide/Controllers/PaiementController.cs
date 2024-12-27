using System.Diagnostics;
using Application.Models;
using Application.Services;
using essaiVide.Models;
using essaiVide.services;
using Microsoft.AspNetCore.Mvc;

namespace essaiVide.Controllers;

    public class PaiementController : Controller
    {
        private readonly ILogger<PaiementController> _logger;
        private readonly IClientService _clientService;
        private readonly IPaiementService _paiementService;


        /* 
            ViewBag => Recup�rer le m�me type
            ViewData => Dictionnaire durant une requ�te C => V | V => C
            TempData => Dictionnaire durant des requ�tes successives
         */

        public PaiementController(ILogger<PaiementController> logger, IClientService clientService, IPaiementService paiementService)
        {
            _logger = logger;
            _clientService = clientService;
        _paiementService = paiementService;
        }
        // Home/Index | Routes
        

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
        public async Task<IActionResult> Create(Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                
                var clientAdded = await _paiementService.Create(paiement);
                // if (clientAdded != null)
                // {
                TempData["Message"] = "Client cr�� avec succ�s!";
                return RedirectToAction(nameof(Index));
                // }
            }
            return View(paiement);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
   

    }
