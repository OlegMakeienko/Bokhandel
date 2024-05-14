using Bokhandel.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bokhandel.Controllers;

[Authorize]
public class StoreController : Controller
{
    private readonly BokhandelContext _context;

    public StoreController(BokhandelContext context)
    {
        _context = context;
    }
    
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Books.ToListAsync());
    }
    
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Books
            .FirstOrDefaultAsync(m => m.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }
}