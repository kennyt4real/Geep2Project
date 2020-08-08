using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Geep.DataAccess.Context;
using Geep.Models.Core;

namespace Geep.Web.Controllers
{
    public class LocalGovernmentAreasController : Controller
    {
        private readonly GeepDbContext _context;

        public LocalGovernmentAreasController(GeepDbContext context)
        {
            _context = context;
        }

        // GET: LocalGovernmentAreas
        public async Task<IActionResult> Index()
        {
            var geepDbContext = _context.LocalGovernmentAreas.Include(l => l.State);
            return View(await geepDbContext.ToListAsync());
        }

        // GET: LocalGovernmentAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localGovernmentArea = await _context.LocalGovernmentAreas
                .Include(l => l.State)
                .FirstOrDefaultAsync(m => m.LocalGovernmentAreaId == id);
            if (localGovernmentArea == null)
            {
                return NotFound();
            }

            return View(localGovernmentArea);
        }

        // GET: LocalGovernmentAreas/Create
        public IActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId");
            return View();
        }

        // POST: LocalGovernmentAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalGovernmentAreaId,StateId,LgaName,ReferenceId,CreatedBy,DateCreated,DateUpdated,UpdatedBy")] LocalGovernmentArea localGovernmentArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localGovernmentArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", localGovernmentArea.StateId);
            return View(localGovernmentArea);
        }

        // GET: LocalGovernmentAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localGovernmentArea = await _context.LocalGovernmentAreas.FindAsync(id);
            if (localGovernmentArea == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", localGovernmentArea.StateId);
            return View(localGovernmentArea);
        }

        // POST: LocalGovernmentAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocalGovernmentAreaId,StateId,LgaName,ReferenceId,CreatedBy,DateCreated,DateUpdated,UpdatedBy")] LocalGovernmentArea localGovernmentArea)
        {
            if (id != localGovernmentArea.LocalGovernmentAreaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localGovernmentArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalGovernmentAreaExists(localGovernmentArea.LocalGovernmentAreaId))
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
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", localGovernmentArea.StateId);
            return View(localGovernmentArea);
        }

        // GET: LocalGovernmentAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localGovernmentArea = await _context.LocalGovernmentAreas
                .Include(l => l.State)
                .FirstOrDefaultAsync(m => m.LocalGovernmentAreaId == id);
            if (localGovernmentArea == null)
            {
                return NotFound();
            }

            return View(localGovernmentArea);
        }

        // POST: LocalGovernmentAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localGovernmentArea = await _context.LocalGovernmentAreas.FindAsync(id);
            _context.LocalGovernmentAreas.Remove(localGovernmentArea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalGovernmentAreaExists(int id)
        {
            return _context.LocalGovernmentAreas.Any(e => e.LocalGovernmentAreaId == id);
        }
    }
}
