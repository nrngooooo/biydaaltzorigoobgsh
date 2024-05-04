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
    public class BookgiveController : Controller
    {
        private readonly Nomiinsanctx _context;

        public BookgiveController(Nomiinsanctx context)
        {
            _context = context;
        }

        // GET: Bookgive
        public async Task<IActionResult> Index()
        {
            var nomiinsanctx = _context.bookgives.Include(b => b.book).Include(b => b.user).Include(b => b.worker);
            return View(await nomiinsanctx.ToListAsync());
        }

        // GET: Bookgive/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookgive = await _context.bookgives
                .Include(b => b.book)
                .Include(b => b.user)
                .Include(b => b.worker)
                .FirstOrDefaultAsync(m => m.bookgiveId == id);
            if (bookgive == null)
            {
                return NotFound();
            }

            return View(bookgive);
        }

        // GET: Bookgive/Create
        public IActionResult Create()
        {
            ViewData["bookId"] = new SelectList(_context.books, "bookId", "bookName");
            ViewData["userId"] = new SelectList(_context.users, "userId", "userName");
            ViewData["workerId"] = new SelectList(_context.workers, "workerId", "workerName");
            return View();
        }

        // POST: Bookgive/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bookgiveId,bookId,userId,workerId,enterdate,retdate")] Bookgive bookgive)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(bookgive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["bookId"] = new SelectList(_context.books, "bookId", "bookName", bookgive.bookId);
            ViewData["userId"] = new SelectList(_context.users, "userId", "userName", bookgive.userId);
            ViewData["workerId"] = new SelectList(_context.workers, "workerId", "workerName", bookgive.workerId);
            return View(bookgive);
        }

        // GET: Bookgive/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookgive = await _context.bookgives.FindAsync(id);
            if (bookgive == null)
            {
                return NotFound();
            }
            ViewData["bookId"] = new SelectList(_context.books, "bookId", "bookName", bookgive.bookId);
            ViewData["userId"] = new SelectList(_context.users, "userId", "userName", bookgive.userId);
            ViewData["workerId"] = new SelectList(_context.workers, "workerId", "workerName", bookgive.workerId);
            return View(bookgive);
        }

        // POST: Bookgive/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bookgiveId,bookId,userId,workerId,enterdate,retdate")] Bookgive bookgive)
        {
            if (id != bookgive.bookgiveId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookgive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookgiveExists(bookgive.bookgiveId))
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
            ViewData["bookId"] = new SelectList(_context.books, "bookId", "bookName", bookgive.bookId);
            ViewData["userId"] = new SelectList(_context.users, "userId", "userName", bookgive.userId);
            ViewData["workerId"] = new SelectList(_context.workers, "workerId", "workerName", bookgive.workerId);
            return View(bookgive);
        }

        // GET: Bookgive/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookgive = await _context.bookgives
                .Include(b => b.book)
                .Include(b => b.user)
                .Include(b => b.worker)
                .FirstOrDefaultAsync(m => m.bookgiveId == id);
            if (bookgive == null)
            {
                return NotFound();
            }

            return View(bookgive);
        }

        // POST: Bookgive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookgive = await _context.bookgives.FindAsync(id);
            if (bookgive != null)
            {
                _context.bookgives.Remove(bookgive);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookgiveExists(int id)
        {
            return _context.bookgives.Any(e => e.bookgiveId == id);
        }
    }
}
