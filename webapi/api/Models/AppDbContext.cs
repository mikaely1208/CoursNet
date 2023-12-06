namespace webapi;
using Microsoft.EntityFrameworkCore; // plugins qui vient d'être installer par `dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0`

// ce fichier sert à initialiser le context et le faire pointer vers la table Books
public class AppDbContext : DbContext
{
   
        // Remplacer la connection String par une connection strign valide, plus tard utiliser la config pour la connection string
        // comment trouver le serveur de base de donnée, le nom de la base de donnée, le nom d'utilisateur et le mot de passe

   private static readonly string path = Path.Combine("..", "LocalDatabase.db"); // chemin vers la base de donnée
   
   private static readonly string ConnectionString = ($"Filename={path}"); // connection string pour la base de donnée
   
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // sert à initialiser le context
   {
       var currentDirectory = Directory.GetCurrentDirectory(); // chemin vers le dossier courant
       Console.WriteLine(currentDirectory); // affiche le chemin vers le dossier courant
       optionsBuilder.UseSqlite(ConnectionString); // utilise la connection string
   }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "Professional C# 6 and .NET Core 1.0",
                Author = "Christian Nagel",
                Description = "A true masterclass in C# and .NET programming",
                Genre = "Software",
                Price = 50,
                PublishDate = new DateTime(2016, 05, 09)
            },
            new Book
            {
                Id = 2,
                Title = "Professional C# 7 and .NET Core 2.0",
                Author = "Christian Nagel",
                Description = "A true masterclass in C# and .NET programming",
                Genre = "Software",
                Price = 50,
                PublishDate = new DateTime(2018, 04, 18)
            },
            new Book
            {
                Id = 3,
                Title = "Professional C# 8 and .NET Core 3.0",
                Author = "Christian Nagel",
                Description = "A true masterclass in C# and .NET programming",
                Genre = "Software",
                Price = 50,
                PublishDate = new DateTime(2019, 10, 30)
            },
            new Book
            {
                Id = 4,
                Title = "Professional C# 9 and .NET 5",
                Author = "Christian Nagel",
                Description = "A true masterclass in C# and .NET programming",
                Genre = "Software",
                Price = 50,
                PublishDate = new DateTime(2021, 01, 01)
            },
            new Book
            {
                Id = 5,
                Title = "Beginning Visual C# 2019",
                Author = "Perkins, Reid, and Hammer",
                Description = "The perfect guide to Visual C#",
                Genre = "Software",
                Price = 45,
                PublishDate = new DateTime(2020, 09, 23)
            },
            new Book
            {
                Id = 6,
                Title = "Pro C# 7",
                Author = "Andrew Troelsen",
                Description = "The ultimate C# resource",
                Genre = "Software",
                Price = 50,
                PublishDate = new DateTime(2017, 10, 01)
            });
    }
    
    // Création propriété pour chaque table de la bdd
    public DbSet<Book> Books { get; set; } // à partir de l'entité book on crée la table books


    
}