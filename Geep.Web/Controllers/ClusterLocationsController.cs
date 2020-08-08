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
    public class ClusterLocationsController : Controller
    {
        private readonly GeepDbContext _context;

        public ClusterLocationsController(GeepDbContext context)
        {
            _context = context;
        }

        // GET: ClusterLocations
        public async Task<IActionResult> Index()
        {
            var geepDbContext = _context.ClusterLocations.Include(c => c.State);
            return View(await geepDbContext.ToListAsync());
        }

        // GET: ClusterLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clusterLocation = await _context.ClusterLocations
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.ClusterLocationId == id);
            if (clusterLocation == null)
            {
                return NotFound();
            }

            return View(clusterLocation);
        }

        // GET: ClusterLocations/Create
        public IActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId");
            return View();
        }

        // POST: ClusterLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClusterLocationId,StateId,Name,ReferenceId,CreatedBy,DateCreated,DateUpdated,UpdatedBy")] ClusterLocation clusterLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clusterLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", clusterLocation.StateId);
            return View(clusterLocation);
        }

        // GET: ClusterLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clusterLocation = await _context.ClusterLocations.FindAsync(id);
            if (clusterLocation == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", clusterLocation.StateId);
            return View(clusterLocation);
        }

        // POST: ClusterLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClusterLocationId,StateId,Name,ReferenceId,CreatedBy,DateCreated,DateUpdated,UpdatedBy")] ClusterLocation clusterLocation)
        {
            if (id != clusterLocation.ClusterLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clusterLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClusterLocationExists(clusterLocation.ClusterLocationId))
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
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", clusterLocation.StateId);
            return View(clusterLocation);
        }

        // GET: ClusterLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clusterLocation = await _context.ClusterLocations
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.ClusterLocationId == id);
            if (clusterLocation == null)
            {
                return NotFound();
            }

            return View(clusterLocation);
        }

        // POST: ClusterLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clusterLocation = await _context.ClusterLocations.FindAsync(id);
            _context.ClusterLocations.Remove(clusterLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClusterLocationExists(int id)
        {
            return _context.ClusterLocations.Any(e => e.ClusterLocationId == id);
        }
    }
}
