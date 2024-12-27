using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Application.Services
{

    public interface IUserService
    {
        Task<User?> GetUserByRoleAsync(string role);
        Task AjouterCommandesAUserAsync(int userId, IEnumerable<Commande> commandes);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> Create(User user);
    }
}