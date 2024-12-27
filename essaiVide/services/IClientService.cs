using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Application.Services
{

    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> Create(Client client);
        Task<IEnumerable<Commande>> GetCommandesByClientAsync(int client);
        Task<IEnumerable<Paiement>> GetPaiementsByClientAsync(int clientId);
    }
}