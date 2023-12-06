namespace webapi.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookService.Models;
using AutoMapper;
// ce fichier contient le controlleur d'api pour books 

[ApiController] // indique a l'execution que cette classe est un controlleur d'api 
[Route("api/[controller]")] // définie le chemin racine de ttes les routes qui doivent arriver dans cette instance
public class BooksController : ControllerBase
{
       
    public readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public BooksController(AppDbContext context, IMapper mapper) // cette ligne sert a initialiser le context et le faire pointer vers la table Books 
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("mapping")]
    public async Task<ActionResult<Book>> Get(BookDTO book)
    {
        var mappedBook = _mapper.Map<Book>(book);
        _context.Books.Add(mappedBook);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = mappedBook.Id }, mappedBook);
    }

    [HttpPost("mapping")]
    public async Task<ActionResult<Book>> Post(BookDTO book)
    {
        var mappedBook = _mapper.Map<Book>(book);
        _context.Books.Add(mappedBook);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = mappedBook.Id }, mappedBook);
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

  [HttpGet("dto")]
  public async Task<ActionResult<BookGetDTO>> GetBookDTO(string title)
  {
      var book = await _context.Books.FirstOrDefaultAsync(b => b.Title == title);
      if (book == null)
      {
          return NotFound();
      }
      var bookDTO = new BookGetDTO
      {
          Title = book.Title,
          Author = book.Author,
          Genre = book.Genre,
          PublishDate = book.PublishDate,
          Description = book.Description,
          Remarks = book.Remarks
      };
      
      return bookDTO;
  }

  

    // méthode put : api/Book/[id] creer la route qui permet de mettre a jour un livre existant
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Book>> PutBook(int id, [FromBody] BookUpdateDTO book)
    {
        var updatedBook = await _context.Books.FindAsync(id);
    
        if (updatedBook == null)
        {
            return NotFound();
        }
    
        if (updatedBook.Title != book.Title)
        {
            return BadRequest();
        }
        
        // mettre à jour les propriétés du livre ici en utilisant les propriétés du DTO
        updatedBook.Title = book.Title;
        updatedBook.Author = book.Author;
        updatedBook.Genre = book.Genre;
        updatedBook.Price = book.Price;
        updatedBook.Description = book.Description;
        updatedBook.Remarks = book.Remarks;

        await _context.SaveChangesAsync();
    
        return NoContent();
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

