using Libruary.Models;
using Libruary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BookCategoriesController : ControllerBase
{
    private readonly LibraryDbContext _context;

    public BookCategoriesController(LibraryDbContext context)
    {
        _context = context;
    }

    // GET: api/BookCategories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookCategory>>> GetBookCategories()
    {
        return await _context.BookCategories.ToListAsync();
    }

    // GET: api/BookCategories/5/1
    [HttpGet("{bookId}/{categoryId}")]
    public async Task<ActionResult<BookCategory>> GetBookCategory(int bookId, int categoryId)
    {
        var bookCategory = await _context.BookCategories.FindAsync(bookId, categoryId);
        if (bookCategory == null)
        {
            return NotFound();
        }
        return bookCategory;
    }

    // POST: api/BookCategories
    [HttpPost]
    public async Task<ActionResult<BookCategory>> PostBookCategory(BookCategory bookCategory)
    {
        _context.BookCategories.Add(bookCategory);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetBookCategory", new { bookId = bookCategory.BookID, categoryId = bookCategory.CategoryID }, bookCategory);
    }

    // DELETE: api/BookCategories/5/1
    [HttpDelete("{bookId}/{categoryId}")]
    public async Task<IActionResult> DeleteBookCategory(int bookId, int categoryId)
    {
        var bookCategory = await _context.BookCategories.FindAsync(bookId, categoryId);
        if (bookCategory == null)
        {
            return NotFound();
        }

        _context.BookCategories.Remove(bookCategory);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}