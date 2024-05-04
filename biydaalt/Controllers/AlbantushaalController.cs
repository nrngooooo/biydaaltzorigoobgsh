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
    public class AlbantushaalController : Controller
    {
        private readonly Nomiinsanctx _context;

        public AlbantushaalController(Nomiinsanctx context)
        {
            _context = context;
        }

        // GET: Albantushaal
        public async Task<IActionResult> Index()
        {
            return View(await _context.albantushaals.ToListAsync());
        }

        // GET: Albantushaal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albantushaal = await _context.albantushaals
                .FirstOrDefaultAsync(m => m.albantushaalId == id);
            if (albantushaal == null)
            {
                return NotFound();
            }

            return View(albantushaal);
        }

        // GET: Albantushaal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Albantushaal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("albantushaalId,albantushaalName")] Albantushaal albantushaal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(albantushaal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(albantushaal);
        }

        // GET: Albantushaal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albantushaal = await _context.albantushaals.FindAsync(id);
            if (albantushaal == null)
            {
                return NotFound();
            }
            return View(albantushaal);
        }

        // POST: Albantushaal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("albantushaalId,albantushaalName")] Albantushaal albantushaal)
        {
            if (id != albantushaal.albantushaalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(albantushaal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbantushaalExists(albantushaal.albantushaalId))
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
            return View(albantushaal);
        }

        // GET: Albantushaal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albantushaal = await _context.albantushaals
                .FirstOrDefaultAsync(m => m.albantushaalId == id);
            if (albantushaal == null)
            {
                return NotFound();
            }

            return View(albantushaal);
        }

        // POST: Albantushaal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var albantushaal = await _context.albantushaals.FindAsync(id);
            if (albantushaal != null)
            {
                _context.albantushaals.Remove(albantushaal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbantushaalExists(int id)
        {
            return _context.albantushaals.Any(e => e.albantushaalId == id);
        }
    }
}
