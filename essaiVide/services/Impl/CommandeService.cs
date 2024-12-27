using Application.Models;
using Application.Services;
using essaiVide.Data;
using essaiVide.enums;
using Microsoft.EntityFrameworkCore;

namespace essaiVide.services.Impl
{
    public class CommandeService : ICommandeService
    {
        private readonly ApplicationDbContext _context;

        public CommandeService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Commande> Create(Commande commande)
        {

            _context.Commande.Add(commande);

            await _context.SaveChangesAsync();

            return commande;
        }

        public async Task<Commande> CreateCommandeAsync(Commande commande)
        {
            commande.EtatCommande = EtatCommande.MiseEnOeuvre;
            commande.EtatSolde = EtatSolde.Impayee;
            _context.Commande.Add(commande);
            await _context.SaveChangesAsync();
            return commande;
        }

        
    }
}
