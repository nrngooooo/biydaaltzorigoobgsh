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
    public class TurulController : Controller
    {
        private readonly Nomiinsanctx _context;

        public TurulController(Nomiinsanctx context)
        {
            _context = context;
        }

        // GET: Turul
        public async Task<IActionResult> Index()
        {
            return View(await _context.turuls.ToListAsync());
        }
        public async Task<IActionResult> Indexu()
        {
            return View(await _context.turuls.ToListAsync());
        }

        // GET: Turul/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turul = await _context.turuls
                .FirstOrDefaultAsync(m => m.turulId == id);
            if (turul == null)
            {
                return NotFound();
            }

            return View(turul);
        }

        // GET: Turul/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turul/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("turulId,turulName")] Turul turul)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turul);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turul);
        }

        // GET: Turul/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turul = await _context.turuls.FindAsync(id);
            if (turul == null)
            {
                return NotFound();
            }
            return View(turul);
        }

        // POST: Turul/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("turulId,turulName")] Turul turul)
        {
            if (id != turul.turulId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turul);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurulExists(turul.turulId))
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
            return View(turul);
        }

        // GET: Turul/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turul = await _context.turuls
                .FirstOrDefaultAsync(m => m.turulId == id);
            if (turul == null)
            {
                return NotFound();
            }

            return View(turul);
        }

        // POST: Turul/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turul = await _context.turuls.FindAsync(id);
            if (turul != null)
            {
                _context.turuls.Remove(turul);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurulExists(int id)
        {
            return _context.turuls.Any(e => e.turulId == id);
        }
    }
}
