namespace webapi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController] // indique a l'execution que cette classe est un controlleur d'api 
[Route("api/[controller]")] // définie le chemin racine de ttes les routes qui doivent arriver dans cette instance
public class BooksController : ControllerBase
{
    private readonly AppDbContext _context;

    public BooksController(AppDbContext context) // cette ligne sert a initialiser le context et le faire pointer vers la table Books 
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Book>> Get()
    {
    
        return await _context.Books.ToListAsync();

    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Book))]
    [ProducesResponseType(400)]
   public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
   {
       if (book == null)
       {
           return BadRequest();
       }
       Book? addedBook = await _context.Books.FirstOrDefaultAsync(b => b.Title == book.Title);
       if (addedBook != null)
       {
           return BadRequest("Ce livre existe déjà");
       }
       else 
       {
           await _context.Books.AddAsync(book);
           await _context.SaveChangesAsync();
   
           return CreatedAtRoute(
               "GetBook",
               routeValues: new { id = book.Id },
               value: book);
       }
   }

    //Trouver les livres par id en methode get
    [HttpGet("{id}", Name=nameof(GetBook))]
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
    [HttpPut("{id}")]
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
    [HttpDelete("{id}")]
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

