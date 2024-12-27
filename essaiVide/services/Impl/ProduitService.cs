using Application.Models;
using Application.Services;
using essaiVide.Data;
using essaiVide.enums;
using Microsoft.EntityFrameworkCore;

namespace essaiVide.services.Impl
{
    public class ProduittService : IProduitService
    {
        private readonly ApplicationDbContext _context;

        public ProduittService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Produit> Create(Produit produit)
        {

            _context.Produit.Add(produit);

            await _context.SaveChangesAsync();

            return produit;
        }

        public async Task<Paiement> CreatePaiementAsync(Paiement paiement)
        {
            _context.Paiements.Add(paiement);

            await _context.SaveChangesAsync();
            return paiement;
        }

        public async Task<Produit?> UpdateStockAsync(int produitId, int nouvelleQuantite)
        {
            // Recherche du produit dans la base de données
            var produit = await _context.Produit.FirstOrDefaultAsync(p => p.Id == produitId);

            if (produit == null)
            {
                // Retourne null si le produit n'existe pas
                return null;
            }

            // Mise à jour de la quantité en stock
            produit.QteStock = nouvelleQuantite;

            // Enregistrement des changements
            await _context.SaveChangesAsync();

            return produit;
        }

    }
}
