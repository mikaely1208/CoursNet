namespace webapi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// ce fichier contient le controlleur d'api pour books 

[ApiController] // indique a l'execution que cette classe est un controlleur d'api 
[Route("api/[controller]")] // définie le chemin racine de ttes les routes qui doivent arriver dans cette instance
public class BooksController : ControllerBase
{
    private readonly AppDbContext _context;

    public BooksController(AppDbContext context) // cette ligne sert a initialiser le context et le faire pointer vers la table Books 
    {
        _context = context;
    }

    [HttpGet] // indique a l'execution que cette methode est une methode get
    public async Task<IEnumerable<Book>> Get() // cette ligne sert à recuperer tous les livres avec la methode Get
    {
    
        return await _context.Books.ToListAsync();// ici on utilise await car on est dans une tache asynchrone

    }

    [HttpPost] // indique a l'execution que cette methode est une methode post
    [ProducesResponseType(201, Type = typeof(Book))] // indique a l'execution que cette methode renvoie un code 201
    [ProducesResponseType(400)] // indique a l'execution que cette methode renvoie un code 400
   public async Task<ActionResult<Book>> PostBook([FromBody] Book book) // cette ligne sert à ajouter un livre avec la methode Post
   {
       if (book == null)
       {
           return BadRequest();
       }
       Book? addedBook = await _context.Books.FirstOrDefaultAsync(b => b.Title == book.Title); // FirstOrDefaultAsync fonctionne comme FindAsync mais renvoie le premier element
       if (addedBook != null)
       {
           return BadRequest("Ce livre existe déjà");
       }
       else 
       {
           await _context.Books.AddAsync(book); // AddAsync fonctionne comme Add mais renvoie une tache asynchrone
           await _context.SaveChangesAsync(); // SaveChangesAsync fonctionne comme SaveChanges mais renvoie une tache asynchrone
   
           return CreatedAtRoute( // methode CreatedAtRoute pour créer une réponse HTTP avec un code de statut 201 (Créé) et un en-tête Location qui spécifie l'URI de la ressource
               "GetBook",
               routeValues: new { id = book.Id }, // routeValues est un dictionnaire qui contient les paramètres de la route
               value: book);
       }
   }

    //Trouver les livres par id en methode get
    [HttpGet("{id}", Name=nameof(GetBook))] // indique a l'execution que cette methode est une methode get
    public async Task<ActionResult<Book>> GetBook(int id) 
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return book;
    }

    // méthode put : api/Book/[id] creer la route qui permet de mettre a jour un livre existant
    [HttpPut("{id}")] // indique a l'execution que cette methode est une methode put
    public async Task<ActionResult> PutBook(int id, [FromBody] Book book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }
        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok();
    }

    // méthode delete : api/Book/[id] creer la route qui permet de supprimer un livre existant
    [HttpDelete("{id}")] // indique a l'execution que cette methode est une methode delete
    public async Task<ActionResult> DeleteBook(int id) 
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return Ok();
    }

}

