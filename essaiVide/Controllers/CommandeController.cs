using System.Diagnostics;
using Application.Models;
using Application.Services;
using essaiVide.Models;
using essaiVide.services;
using Microsoft.AspNetCore.Mvc;

namespace essaiVide.Controllers;

public class CommandeController : Controller
{
    private readonly ILogger<CommandeController> _logger;
    private readonly ICommandeService _commandeService;
    private readonly IClientService _clientService;


    /* 
        ViewBag => Recupérer le même type
        ViewData => Dictionnaire durant une requête C => V | V => C
        TempData => Dictionnaire durant des requêtes successives
     */

    public CommandeController(ILogger<CommandeController> logger, ICommandeService commandeService, IClientService clientService)
    {
        _logger = logger;
        _commandeService = commandeService;
        _clientService = clientService;

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



    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Commande commande)
    {
        if (ModelState.IsValid)
        {
            var clientAdded = await _commandeService.Create(commande);
            // if (clientAdded != null)
            // {
            TempData["Message"] = "Client créé avec succès!";
            return RedirectToAction(nameof(Index));
            // }
        }
        return View(commande);
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}
