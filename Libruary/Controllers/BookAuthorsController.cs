using Libruary.Models;
using Libruary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BookAuthorsController : ControllerBase
{
    private readonly LibraryDbContext _context;

    public BookAuthorsController(LibraryDbContext context)
    {
        _context = context;
    }

    // GET: api/BookAuthors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookAuthor>>> GetBookAuthors()
    {
        return await _context.BookAuthors.ToListAsync();
    }

    // GET: api/BookAuthors/5
    [HttpGet("{bookId}/{authorId}")]
    public async Task<ActionResult<BookAuthor>> GetBookAuthor(int bookId, int authorId)
    {
        var bookAuthor = await _context.BookAuthors.FindAsync(bookId, authorId);
        if (bookAuthor == null)
        {
            return NotFound();
        }
        return bookAuthor;
    }

    // POST: api/BookAuthors
    [HttpPost]
    public async Task<ActionResult<BookAuthor>> PostBookAuthor(BookAuthor bookAuthor)
    {
        _context.BookAuthors.Add(bookAuthor);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetBookAuthor", new { bookId = bookAuthor.BookID, authorId = bookAuthor.AuthorID }, bookAuthor);
    }

    // DELETE: api/BookAuthors/5/1
    [HttpDelete("{bookId}/{authorId}")]
    public async Task<IActionResult> DeleteBookAuthor(int bookId, int authorId)
    {
        var bookAuthor = await _context.BookAuthors.FindAsync(bookId, authorId);
        if (bookAuthor == null)
        {
            return NotFound();
        }

        _context.BookAuthors.Remove(bookAuthor);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}