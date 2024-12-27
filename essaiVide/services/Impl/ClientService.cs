using Application.Models;
using Application.Services;
using essaiVide.Data;
using Microsoft.EntityFrameworkCore;

namespace essaiVide.services.Impl
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Client> Create(Client client)
        {

            _context.Clients.Add(client);

            await _context.SaveChangesAsync();

            return client;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            // Your implementation to fetch clients from your data source
            return await _context.Clients.ToListAsync();
        }

        public async Task<IEnumerable<Commande>> GetCommandesByClientAsync(int clientId)
        {
            var client = await _context.Clients
                .Where(c => c.Id == clientId)
                .Include(c => c.Commandes) // Charge les commandes associées
                .FirstOrDefaultAsync();

            return client?.Commandes ?? Enumerable.Empty<Commande>();
        }

        public async Task<IEnumerable<Paiement>> GetPaiementsByClientAsync(int clientId)
        {
            var client = await _context.Clients
                .Where(c => c.Id == clientId)
                .Include(c => c.Commandes) // Charge les commandes associées
                    .ThenInclude(cmd => cmd.Paiement) // Charge les paiements liés aux commandes
                .FirstOrDefaultAsync();

            return client?.Commandes.Select(cmd => cmd.Paiement).Where(p => p != null) ?? Enumerable.Empty<Paiement>();
        }



    }
}
