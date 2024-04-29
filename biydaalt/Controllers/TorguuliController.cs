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
    public class TorguuliController : Controller
    {
        private readonly Nomiinsanctx _context;

        public TorguuliController(Nomiinsanctx context)
        {
            _context = context;
        }

        // GET: Torguuli
        public async Task<IActionResult> Index()
        {
            var nomiinsanctx = _context.Torguulis.Include(t => t.book).Include(t => t.user).Include(t => t.worker);
            return View(await nomiinsanctx.ToListAsync());
        }

        // GET: Torguuli/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torguuli = await _context.Torguulis
                .Include(t => t.book)
                .Include(t => t.user)
                .Include(t => t.worker)
                .FirstOrDefaultAsync(m => m.torguuliId == id);
            if (torguuli == null)
            {
                return NotFound();
            }

            return View(torguuli);
        }

        // GET: Torguuli/Create
        public IActionResult Create()
        {
            ViewData["bookId"] = new SelectList(_context.Books, "bookId", "bookId");
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId");
            ViewData["workerId"] = new SelectList(_context.Workers, "workerId", "workerId");
            return View();
        }

        // POST: Torguuli/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("torguuliId,userId,workerId,bookId,ashigodor,torguulihemje")] Torguuli torguuli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(torguuli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["bookId"] = new SelectList(_context.Books, "bookId", "bookId", torguuli.bookId);
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", torguuli.userId);
            ViewData["workerId"] = new SelectList(_context.Workers, "workerId", "workerId", torguuli.workerId);
            return View(torguuli);
        }

        // GET: Torguuli/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torguuli = await _context.Torguulis.FindAsync(id);
            if (torguuli == null)
            {
                return NotFound();
            }
            ViewData["bookId"] = new SelectList(_context.Books, "bookId", "bookId", torguuli.bookId);
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", torguuli.userId);
            ViewData["workerId"] = new SelectList(_context.Workers, "workerId", "workerId", torguuli.workerId);
            return View(torguuli);
        }

        // POST: Torguuli/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("torguuliId,userId,workerId,bookId,ashigodor,torguulihemje")] Torguuli torguuli)
        {
            if (id != torguuli.torguuliId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(torguuli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TorguuliExists(torguuli.torguuliId))
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
            ViewData["bookId"] = new SelectList(_context.Books, "bookId", "bookId", torguuli.bookId);
            ViewData["userId"] = new SelectList(_context.Users, "userId", "userId", torguuli.userId);
            ViewData["workerId"] = new SelectList(_context.Workers, "workerId", "workerId", torguuli.workerId);
            return View(torguuli);
        }

        // GET: Torguuli/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torguuli = await _context.Torguulis
                .Include(t => t.book)
                .Include(t => t.user)
                .Include(t => t.worker)
                .FirstOrDefaultAsync(m => m.torguuliId == id);
            if (torguuli == null)
            {
                return NotFound();
            }

            return View(torguuli);
        }

        // POST: Torguuli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var torguuli = await _context.Torguulis.FindAsync(id);
            if (torguuli != null)
            {
                _context.Torguulis.Remove(torguuli);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TorguuliExists(int id)
        {
            return _context.Torguulis.Any(e => e.torguuliId == id);
        }
    }
}
