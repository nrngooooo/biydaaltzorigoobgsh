using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using biydaalt.Models;

namespace biydaalt.Controllers
{
    public class BookactController : Controller
    {
        private readonly Nomiinsanctx _context;

        public BookactController(Nomiinsanctx context)
        {
            _context = context;
        }

        // GET: Bookact
        public async Task<IActionResult> Index()
        {
            var nomiinsanctx = _context.Bookacts.Include(b => b.book).Include(b => b.worker);
            return View(await nomiinsanctx.ToListAsync());
        }

        // GET: Bookact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookact = await _context.Bookacts
                .Include(b => b.book)
                .Include(b => b.worker)
                .FirstOrDefaultAsync(m => m.bookactId == id);
            if (bookact == null)
            {
                return NotFound();
            }

            return View(bookact);
        }

        // GET: Bookact/Create
        public IActionResult Create()
        {
            ViewData["bookId"] = new SelectList(_context.Books, "bookId", "bookId");
            ViewData["workerId"] = new SelectList(_context.Workers, "workerId", "workerId");
            return View();
        }

        // POST: Bookact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bookactId,bookId,workerId,act_count,actshaltgaan,actdate")] Bookact bookact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["bookId"] = new SelectList(_context.Books, "bookId", "bookId", bookact.bookId);
            ViewData["workerId"] = new SelectList(_context.Workers, "workerId", "workerId", bookact.workerId);
            return View(bookact);
        }

        // GET: Bookact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookact = await _context.Bookacts.FindAsync(id);
            if (bookact == null)
            {
                return NotFound();
            }
            ViewData["bookId"] = new SelectList(_context.Books, "bookId", "bookId", bookact.bookId);
            ViewData["workerId"] = new SelectList(_context.Workers, "workerId", "workerId", bookact.workerId);
            return View(bookact);
        }

        // POST: Bookact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bookactId,bookId,workerId,act_count,actshaltgaan,actdate")] Bookact bookact)
        {
            if (id != bookact.bookactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookactExists(bookact.bookactId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["bookId"] = new SelectList(_context.Books, "bookId", "bookId", bookact.bookId);
            ViewData["workerId"] = new SelectList(_context.Workers, "workerId", "workerId", bookact.workerId);
            return View(bookact);
        }

        // GET: Bookact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookact = await _context.Bookacts
                .Include(b => b.book)
                .Include(b => b.worker)
                .FirstOrDefaultAsync(m => m.bookactId == id);
            if (bookact == null)
            {
                return NotFound();
            }

            return View(bookact);
        }

        // POST: Bookact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookact = await _context.Bookacts.FindAsync(id);
            if (bookact != null)
            {
                _context.Bookacts.Remove(bookact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookactExists(int id)
        {
            return _context.Bookacts.Any(e => e.bookactId == id);
        }
    }
}
