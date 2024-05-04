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
    public class ActshaltgaanController : Controller
    {
        private readonly Nomiinsanctx _context;

        public ActshaltgaanController(Nomiinsanctx context)
        {
            _context = context;
        }

        // GET: Actshaltgaan
        public async Task<IActionResult> Index()
        {
            return View(await _context.actshaltgaans.ToListAsync());
        }

        // GET: Actshaltgaan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actshaltgaan = await _context.actshaltgaans
                .FirstOrDefaultAsync(m => m.actshaltgaanId == id);
            if (actshaltgaan == null)
            {
                return NotFound();
            }

            return View(actshaltgaan);
        }

        // GET: Actshaltgaan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actshaltgaan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("actshaltgaanId,actshaltgaanName")] Actshaltgaan actshaltgaan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actshaltgaan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actshaltgaan);
        }

        // GET: Actshaltgaan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actshaltgaan = await _context.actshaltgaans.FindAsync(id);
            if (actshaltgaan == null)
            {
                return NotFound();
            }
            return View(actshaltgaan);
        }

        // POST: Actshaltgaan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("actshaltgaanId,actshaltgaanName")] Actshaltgaan actshaltgaan)
        {
            if (id != actshaltgaan.actshaltgaanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actshaltgaan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActshaltgaanExists(actshaltgaan.actshaltgaanId))
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
            return View(actshaltgaan);
        }

        // GET: Actshaltgaan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actshaltgaan = await _context.actshaltgaans
                .FirstOrDefaultAsync(m => m.actshaltgaanId == id);
            if (actshaltgaan == null)
            {
                return NotFound();
            }

            return View(actshaltgaan);
        }

        // POST: Actshaltgaan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actshaltgaan = await _context.actshaltgaans.FindAsync(id);
            if (actshaltgaan != null)
            {
                _context.actshaltgaans.Remove(actshaltgaan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActshaltgaanExists(int id)
        {
            return _context.actshaltgaans.Any(e => e.actshaltgaanId == id);
        }
    }
}
