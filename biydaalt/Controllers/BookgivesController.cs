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
    public class BookgivesController : Controller
    {
        private readonly Nomiinsanctx _context;

        public BookgivesController(Nomiinsanctx context)
        {
            _context = context;
        }

        // GET: Bookgives
        public async Task<IActionResult> Index()
        {
            var nomiinsanctx = _context.Bookgives.Include(b => b.book).Include(b => b.user).Include(b => b.worker);
            return View(await nomiinsanctx.ToListAsync());
        }

        // GET: Bookgives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookgive = await _context.Bookgives
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

        // GET: Bookgives/Create
        public IActionResult Create()
        {
            ViewData["bookId"] = new SelectList(_context.Books, "bookId", "bookId");
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId");
            ViewData["workerId"] = new SelectList(_context.Workers, "workerId", "workerId");
            return View();
        }

        // POST: Bookgives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bookgiveId,bookId,userId,workerId,enterdate,retdate")] Bookgive bookgive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookgive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["bookId"] = new SelectList(_context.Books, "bookId", "bookId", bookgive.bookId);
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", bookgive.userId);
            ViewData["workerId"] = new SelectList(_context.Workers, "workerId", "workerId", bookgive.workerId);
            return View(bookgive);
        }

        // GET: Bookgives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookgive = await _context.Bookgives.FindAsync(id);
            if (bookgive == null)
            {
                return NotFound();
            }
            ViewData["bookId"] = new SelectList(_context.Books, "bookId", "bookId", bookgive.bookId);
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", bookgive.userId);
            ViewData["workerId"] = new SelectList(_context.Workers, "workerId", "workerId", bookgive.workerId);
            return View(bookgive);
        }

        // POST: Bookgives/Edit/5
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

            if (ModelState.IsValid)
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
            ViewData["bookId"] = new SelectList(_context.Books, "bookId", "bookId", bookgive.bookId);
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", bookgive.userId);
            ViewData["workerId"] = new SelectList(_context.Workers, "workerId", "workerId", bookgive.workerId);
            return View(bookgive);
        }

        // GET: Bookgives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookgive = await _context.Bookgives
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

        // POST: Bookgives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookgive = await _context.Bookgives.FindAsync(id);
            if (bookgive != null)
            {
                _context.Bookgives.Remove(bookgive);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookgiveExists(int id)
        {
            return _context.Bookgives.Any(e => e.bookgiveId == id);
        }
    }
}
