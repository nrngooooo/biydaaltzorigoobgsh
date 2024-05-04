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
    public class DedturulController : Controller
    {
        private readonly Nomiinsanctx _context;

        public DedturulController(Nomiinsanctx context)
        {
            _context = context;
        }

        // GET: Dedturul
        public async Task<IActionResult> Index()
        {
            var nomiinsanctx = _context.dedTuruls.Include(d => d.turul);
            return View(await nomiinsanctx.ToListAsync());
        }

        // GET: Dedturul/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dedturul = await _context.dedTuruls
                .Include(d => d.turul)
                .FirstOrDefaultAsync(m => m.dedTurulId == id);
            if (dedturul == null)
            {
                return NotFound();
            }

            return View(dedturul);
        }

        // GET: Dedturul/Create
        public IActionResult Create()
        {
            ViewData["turulId"] = new SelectList(_context.turuls, "turulId", "turulName");
            return View();
        }

        // POST: Dedturul/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("dedTurulId,dedTurulName,turulId")] Dedturul dedturul)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(dedturul);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["turulId"] = new SelectList(_context.turuls, "turulId", "turulName", dedturul.turulId);
            return View(dedturul);
        }

        // GET: Dedturul/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dedturul = await _context.dedTuruls.FindAsync(id);
            if (dedturul == null)
            {
                return NotFound();
            }
            ViewData["turulId"] = new SelectList(_context.turuls, "turulId", "turulName", dedturul.turulId);
            return View(dedturul);
        }

        // POST: Dedturul/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("dedTurulId,dedTurulName,turulId")] Dedturul dedturul)
        {
            if (id != dedturul.dedTurulId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(dedturul);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DedturulExists(dedturul.dedTurulId))
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
            ViewData["turulId"] = new SelectList(_context.turuls, "turulId", "turulName", dedturul.turulId);
            return View(dedturul);
        }

        // GET: Dedturul/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dedturul = await _context.dedTuruls
                .Include(d => d.turul)
                .FirstOrDefaultAsync(m => m.dedTurulId == id);
            if (dedturul == null)
            {
                return NotFound();
            }

            return View(dedturul);
        }

        // POST: Dedturul/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dedturul = await _context.dedTuruls.FindAsync(id);
            if (dedturul != null)
            {
                _context.dedTuruls.Remove(dedturul);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DedturulExists(int id)
        {
            return _context.dedTuruls.Any(e => e.dedTurulId == id);
        }
    }
}
