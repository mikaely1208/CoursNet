namespace webapi;
using Microsoft.EntityFrameworkCore; // plugins qui vient d'être installer par `dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0`
public class AppDbContext : DbContext
{
   
        // Remplacer la connection String par une connection strign valide, plus tard utiliser la config pour la connection string
        // comment trouver le serveur de base de donnée, le nom de la base de donnée, le nom d'utilisateur et le mot de passe

   private static readonly string path = Path.Combine("..", "LocalDatabase.db");
   
   private static readonly string ConnectionString = ($"Filename={path}");
   
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       var currentDirectory = Directory.GetCurrentDirectory();
       Console.WriteLine(currentDirectory);
       optionsBuilder.UseSqlite(ConnectionString);
   }

    
    // Création propriété pour chaque table de la bdd
    public DbSet<Book> Books { get; set; } // à partir de l'entité book on crée la table books


    
}