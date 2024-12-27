using Application.Models;
using Application.Services;
using essaiVide.Data;
using essaiVide.enums;
using Microsoft.EntityFrameworkCore;

namespace essaiVide.services.Impl
{
    public class PaiementService : IPaiementService
    {
        private readonly ApplicationDbContext _context;

        public PaiementService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Paiement> Create(Paiement paiement)
        {

            _context.Paiements.Add(paiement);

            await _context.SaveChangesAsync();

            return paiement;
        }

        public async Task<Paiement> CreatePaiementAsync(Paiement paiement)
        {
            _context.Paiements.Add(paiement);

            await _context.SaveChangesAsync();
            return paiement;
        }
    }
}
