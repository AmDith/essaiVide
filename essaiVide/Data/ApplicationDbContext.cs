using Application.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace essaiVide.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Client>()
             .HasOne(client => client.User) // Un Client a un User
             .WithOne() // Pas de navigation inverse
             .HasForeignKey<Client>(client => client.UserId) // Clé étrangère définie dans Client
             .OnDelete(DeleteBehavior.Cascade) // Suppression en cascade
             .IsRequired(false); // La relation est facultative

        modelBuilder.Entity<Client>()
            .HasMany(c => c.Versements)
            .WithOne(v => v.Client)
            .HasForeignKey(v => v.ClientId)
            .OnDelete(DeleteBehavior.Cascade) // Suppression en cascade
            .IsRequired(false);

        modelBuilder.Entity<Client>()
            .HasMany(c => c.Commandes)
            .WithOne();

        modelBuilder.Entity<User>()
            .HasMany(u => u.Commandes)
            .WithOne();

        modelBuilder.Entity<User>()
            .HasMany(u => u.Produits)
            .WithOne();

        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany() 
            .HasForeignKey(u => u.RoleId) 
            .OnDelete(DeleteBehavior.Cascade) 
            .IsRequired(false);

        modelBuilder.Entity<Livraison>()
            .HasOne(l => l.Livreur) // Chaque Livraison est associée à un Livreur
            .WithMany() // Un Livreur peut avoir plusieurs Livraisons, mais la navigation inverse n'est pas définie
            .HasForeignKey(l => l.LivreurId) // Clé étrangère dans Livraison
            .OnDelete(DeleteBehavior.Cascade) // Suppression en cascade
            .IsRequired(false); // La relation est facultative

        modelBuilder.Entity<Commande>()
             .HasOne(c => c.Livraison) // Un Client a un User
             .WithOne() // Pas de navigation inverse
             .HasForeignKey<Commande>(c => c.LivraisonId) // Clé étrangère définie dans Client
             .OnDelete(DeleteBehavior.Cascade) // Suppression en cascade
             .IsRequired(false);

        modelBuilder.Entity<Commande>()
             .HasOne(c => c.Paiement) // Un Client a un User
             .WithOne() // Pas de navigation inverse
             .HasForeignKey<Commande>(c => c.PaiementId) // Clé étrangère définie dans Client
             .OnDelete(DeleteBehavior.Cascade) // Suppression en cascade
             .IsRequired(false);

        modelBuilder.Entity<Commande>()
             .HasOne(c => c.Facture) // Un Client a un User
             .WithOne() // Pas de navigation inverse
             .HasForeignKey<Commande>(c => c.FactureId) // Clé étrangère définie dans Client
             .OnDelete(DeleteBehavior.Cascade) // Suppression en cascade
             .IsRequired(false);

        modelBuilder.Entity<Commande>()
            .HasOne(c => c.Colis)
            .WithOne(co => co.Commande)
            .HasForeignKey<Colis>(co => co.CommandeId)
            .OnDelete(DeleteBehavior.Cascade) // Suppression en cascade
            .IsRequired(false);

        modelBuilder.Entity<Commande>()
            .HasMany(c => c.Lignes)
            .WithOne(lc => lc.Commande)
            .HasForeignKey(lc => lc.CommandeId)
            .OnDelete(DeleteBehavior.Cascade) // Suppression en cascade
            .IsRequired(false);

        modelBuilder.Entity<Produit>()
            .HasMany(p => p.Lignes)
            .WithOne(lc => lc.Produit)
            .HasForeignKey(lc => lc.ProduitId)
            .OnDelete(DeleteBehavior.Cascade) // Suppression en cascade
            .IsRequired(false);

        

    }
    // Define your DbSet properties here.
    public DbSet<Client> Clients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Paiement> Paiements { get; set; }
    public DbSet<Colis> Colis { get; set; }
    public DbSet<Commande> Commande{ get; set; }
    public DbSet<Facture> Facture{ get; set; }
    public DbSet<LigneCommande> LigneCommande { get; set; }
    public DbSet<Livraison> Livraison { get; set; }
    public DbSet<Livreur> Livreur { get; set; }
    public DbSet<Produit> Produit { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Versement> Versements { get; set; }

    /* 
        On ne peut pas augmenter la visibilité d'un attribut ou d'une méthode héritée

        * private (visible uniquement dans la classe elle même)

        * protected (visibile dans toutes les classes filles uniquement)

        * internal (visible dans le namespace)

        * public (visible partout)

        modelBuilder.Entity<Client>().ToTable("clients") => Changer le nom des tables
     */


}