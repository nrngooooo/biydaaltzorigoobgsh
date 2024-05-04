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
    public class BookController : Controller
    {
        private readonly Nomiinsanctx _context;

        public BookController(Nomiinsanctx context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var nomiinsanctx = _context.books.Include(b => b.dedturuluud).Include(b => b.turuluud).Include(b => b.worker);
            return View(await nomiinsanctx.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.books
                .Include(b => b.dedturuluud)
                .Include(b => b.turuluud)
                .Include(b => b.worker)
                .FirstOrDefaultAsync(m => m.bookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["dedTurulId"] = new SelectList(_context.dedTuruls, "dedTurulId", "dedTurulName");
            ViewData["turulId"] = new SelectList(_context.turuls, "turulId", "turulName");
            ViewData["workerId"] = new SelectList(_context.workers, "workerId", "workerName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bookId,bookName,bookimage,author,page_count,turulId,dedTurulId,book_count,pub_date,pub_company,price,workerId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["dedTurulId"] = new SelectList(_context.dedTuruls, "dedTurulId", "dedTurulName", book.dedTurulId);
            ViewData["turulId"] = new SelectList(_context.turuls, "turulId", "turulName", book.turulId);
            ViewData["workerId"] = new SelectList(_context.workers, "workerId", "workerName", book.workerId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["dedTurulId"] = new SelectList(_context.dedTuruls, "dedTurulId", "dedTurulName", book.dedTurulId);
            ViewData["turulId"] = new SelectList(_context.turuls, "turulId", "turulName", book.turulId);
            ViewData["workerId"] = new SelectList(_context.workers, "workerId", "workerName", book.workerId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bookId,bookName,bookimage,author,page_count,turulId,dedTurulId,book_count,pub_date,pub_company,price,workerId")] Book book)
        {
            if (id != book.bookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.bookId))
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
            ViewData["dedTurulId"] = new SelectList(_context.dedTuruls, "dedTurulId", "dedTurulName", book.dedTurulId);
            ViewData["turulId"] = new SelectList(_context.turuls, "turulId", "turulName", book.turulId);
            ViewData["workerId"] = new SelectList(_context.workers, "workerId", "workerName", book.workerId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.books
                .Include(b => b.dedturuluud)
                .Include(b => b.turuluud)
                .Include(b => b.worker)
                .FirstOrDefaultAsync(m => m.bookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.books.FindAsync(id);
            if (book != null)
            {
                _context.books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.books.Any(e => e.bookId == id);
        }
    }
}
