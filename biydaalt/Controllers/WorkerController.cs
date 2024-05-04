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
    public class WorkerController : Controller
    {
        private readonly Nomiinsanctx _context;

        public WorkerController(Nomiinsanctx context)
        {
            _context = context;
        }

        // GET: Worker
        public async Task<IActionResult> Index()
        {
            var nomiinsanctx = _context.workers.Include(w => w.albantushaal).Include(w => w.department);
            return View(await nomiinsanctx.ToListAsync());
        }

        // GET: Worker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.workers
                .Include(w => w.albantushaal)
                .Include(w => w.department)
                .FirstOrDefaultAsync(m => m.workerId == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // GET: Worker/Create
        public IActionResult Create()
        {
            ViewData["albantushaalId"] = new SelectList(_context.albantushaals, "albantushaalId", "albantushaalName");
            ViewData["departmentId"] = new SelectList(_context.departments, "departmentId", "departmentName");
            return View();
        }

        // POST: Worker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("workerId,workerName,departmentId,albantushaalId,regdug,phone")] Worker worker)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(worker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["albantushaalId"] = new SelectList(_context.albantushaals, "albantushaalId", "albantushaalId", worker.albantushaalId);
            ViewData["departmentId"] = new SelectList(_context.departments, "departmentId", "departmentName", worker.departmentId);
            return View(worker);
        }

        // GET: Worker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }
            ViewData["albantushaalId"] = new SelectList(_context.albantushaals, "albantushaalId", "albantushaalName", worker.albantushaalId);
            ViewData["departmentId"] = new SelectList(_context.departments, "departmentId", "departmentName", worker.departmentId);
            return View(worker);
        }

        // POST: Worker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("workerId,workerName,departmentId,albantushaalId,regdug,phone")] Worker worker)
        {
            if (id != worker.workerId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(worker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerExists(worker.workerId))
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
            ViewData["albantushaalId"] = new SelectList(_context.albantushaals, "albantushaalId", "albantushaalName", worker.albantushaalId);
            ViewData["departmentId"] = new SelectList(_context.departments, "departmentId", "departmentName", worker.departmentId);
            return View(worker);
        }

        // GET: Worker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.workers
                .Include(w => w.albantushaal)
                .Include(w => w.department)
                .FirstOrDefaultAsync(m => m.workerId == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // POST: Worker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var worker = await _context.workers.FindAsync(id);
            if (worker != null)
            {
                _context.workers.Remove(worker);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerExists(int id)
        {
            return _context.workers.Any(e => e.workerId == id);
        }
    }
}
