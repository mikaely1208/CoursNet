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
    public async Task Post([FromBody] Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    //Trouver les livres par id en methode get
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> Get(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return book;
    }
}