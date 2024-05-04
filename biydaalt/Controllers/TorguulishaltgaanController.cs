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
    public class TorguulishaltgaanController : Controller
    {
        private readonly Nomiinsanctx _context;

        public TorguulishaltgaanController(Nomiinsanctx context)
        {
            _context = context;
        }

        // GET: Torguulishaltgaan
        public async Task<IActionResult> Index()
        {
            return View(await _context.torguulishaltgaans.ToListAsync());
        }

        // GET: Torguulishaltgaan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torguulishaltgaan = await _context.torguulishaltgaans
                .FirstOrDefaultAsync(m => m.torguulishaltgaanId == id);
            if (torguulishaltgaan == null)
            {
                return NotFound();
            }

            return View(torguulishaltgaan);
        }

        // GET: Torguulishaltgaan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Torguulishaltgaan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("torguulishaltgaanId,torguulishaltgaanName")] Torguulishaltgaan torguulishaltgaan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(torguulishaltgaan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(torguulishaltgaan);
        }

        // GET: Torguulishaltgaan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torguulishaltgaan = await _context.torguulishaltgaans.FindAsync(id);
            if (torguulishaltgaan == null)
            {
                return NotFound();
            }
            return View(torguulishaltgaan);
        }

        // POST: Torguulishaltgaan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("torguulishaltgaanId,torguulishaltgaanName")] Torguulishaltgaan torguulishaltgaan)
        {
            if (id != torguulishaltgaan.torguulishaltgaanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(torguulishaltgaan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TorguulishaltgaanExists(torguulishaltgaan.torguulishaltgaanId))
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
            return View(torguulishaltgaan);
        }

        // GET: Torguulishaltgaan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torguulishaltgaan = await _context.torguulishaltgaans
                .FirstOrDefaultAsync(m => m.torguulishaltgaanId == id);
            if (torguulishaltgaan == null)
            {
                return NotFound();
            }

            return View(torguulishaltgaan);
        }

        // POST: Torguulishaltgaan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var torguulishaltgaan = await _context.torguulishaltgaans.FindAsync(id);
            if (torguulishaltgaan != null)
            {
                _context.torguulishaltgaans.Remove(torguulishaltgaan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TorguulishaltgaanExists(int id)
        {
            return _context.torguulishaltgaans.Any(e => e.torguulishaltgaanId == id);
        }
    }
}
