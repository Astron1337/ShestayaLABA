using Libruary.Models;
using Libruary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BookPublishersController : ControllerBase
{
    private readonly LibraryDbContext _context;

    public BookPublishersController(LibraryDbContext context)
    {
        _context = context;
    }

    // GET: api/BookPublishers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookPublisher>>> GetBookPublishers()
    {
        return await _context.BookPublishers.ToListAsync();
    }

    // GET: api/BookPublishers/5/1
    [HttpGet("{bookId}/{publisherId}")]
    public async Task<ActionResult<BookPublisher>> GetBookPublisher(int bookId, int publisherId)
    {
        var bookPublisher = await _context.BookPublishers.FindAsync(bookId, publisherId);
        if (bookPublisher == null)
        {
            return NotFound();
        }
        return bookPublisher;
    }

    // POST: api/BookPublishers
    [HttpPost]
    public async Task<ActionResult<BookPublisher>> PostBookPublisher(BookPublisher bookPublisher)
    {
        _context.BookPublishers.Add(bookPublisher);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetBookPublisher", new { bookId = bookPublisher.BookID, publisherId = bookPublisher.PublisherID }, bookPublisher);
    }

    // DELETE: api/BookPublishers/5/1
    [HttpDelete("{bookId}/{publisherId}")]
    public async Task<IActionResult> DeleteBookPublisher(int bookId, int publisherId)
    {
        var bookPublisher = await _context.BookPublishers.FindAsync(bookId, publisherId);
        if (bookPublisher == null)
        {
            return NotFound();
        }

        _context.BookPublishers.Remove(bookPublisher);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}