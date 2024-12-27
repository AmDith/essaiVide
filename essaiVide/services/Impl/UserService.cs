using Application.Models;
using Application.Services;
using essaiVide.Data;
using Microsoft.EntityFrameworkCore;

namespace essaiVide.services.Impl
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<User> Create(User user)
        {

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            // Your implementation to fetch clients from your data source
            return await _context.Users.ToListAsync();
        }



        public async Task AjouterCommandesAUserAsync(int userId, IEnumerable<Commande> commandes)
        {
            // Récupérer l'utilisateur avec ses commandes existantes
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Commandes) // Charge les commandes associées
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("Utilisateur non trouvé.");
            }

            // Ajouter chaque commande à la liste des commandes de l'utilisateur
            foreach (var commande in commandes)
            {
                user.Commandes.Add(commande);
            }

            // Sauvegarder les modifications dans la base de données
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByRoleAsync(string role)
        {
            // Chercher un utilisateur avec le rôle spécifié
            return await _context.Users
                .Where(u => u.Role.NomRole == role) // Filtrer directement par le champ Role
                .FirstOrDefaultAsync();
        }

    }
}
