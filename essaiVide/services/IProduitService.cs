using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Application.Services
{

    public interface IProduitService
    {
        Task<Produit> Create(Produit produit);
        Task<Paiement> CreatePaiementAsync(Paiement paiement);
        Task<Produit?> UpdateStockAsync(int produitId, int nouvelleQuantite);
    }
}