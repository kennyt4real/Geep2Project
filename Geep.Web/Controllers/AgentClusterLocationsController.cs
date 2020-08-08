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
    public class AgentClusterLocationsController : Controller
    {
        private readonly GeepDbContext _context;

        public AgentClusterLocationsController(GeepDbContext context)
        {
            _context = context;
        }

        // GET: AgentClusterLocations
        public async Task<IActionResult> Index()
        {
            var geepDbContext = _context.AgentClusterLocations.Include(a => a.ClusterLocation);
            return View(await geepDbContext.ToListAsync());
        }

        // GET: AgentClusterLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentClusterLocation = await _context.AgentClusterLocations
                .Include(a => a.ClusterLocation)
                .FirstOrDefaultAsync(m => m.AgentClusterLocationId == id);
            if (agentClusterLocation == null)
            {
                return NotFound();
            }

            return View(agentClusterLocation);
        }

        // GET: AgentClusterLocations/Create
        public IActionResult Create()
        {
            ViewData["ClusterLocationId"] = new SelectList(_context.ClusterLocations, "ClusterLocationId", "ClusterLocationId");
            return View();
        }

        // POST: AgentClusterLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgentClusterLocationId,AgentId,ClusterLocationId,CreatedBy,DateCreated,DateUpdated,UpdatedBy")] AgentClusterLocation agentClusterLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agentClusterLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClusterLocationId"] = new SelectList(_context.ClusterLocations, "ClusterLocationId", "ClusterLocationId", agentClusterLocation.ClusterLocationId);
            return View(agentClusterLocation);
        }

        // GET: AgentClusterLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentClusterLocation = await _context.AgentClusterLocations.FindAsync(id);
            if (agentClusterLocation == null)
            {
                return NotFound();
            }
            ViewData["ClusterLocationId"] = new SelectList(_context.ClusterLocations, "ClusterLocationId", "ClusterLocationId", agentClusterLocation.ClusterLocationId);
            return View(agentClusterLocation);
        }

        // POST: AgentClusterLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgentClusterLocationId,AgentId,ClusterLocationId,CreatedBy,DateCreated,DateUpdated,UpdatedBy")] AgentClusterLocation agentClusterLocation)
        {
            if (id != agentClusterLocation.AgentClusterLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agentClusterLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentClusterLocationExists(agentClusterLocation.AgentClusterLocationId))
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
            ViewData["ClusterLocationId"] = new SelectList(_context.ClusterLocations, "ClusterLocationId", "ClusterLocationId", agentClusterLocation.ClusterLocationId);
            return View(agentClusterLocation);
        }

        // GET: AgentClusterLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentClusterLocation = await _context.AgentClusterLocations
                .Include(a => a.ClusterLocation)
                .FirstOrDefaultAsync(m => m.AgentClusterLocationId == id);
            if (agentClusterLocation == null)
            {
                return NotFound();
            }

            return View(agentClusterLocation);
        }

        // POST: AgentClusterLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agentClusterLocation = await _context.AgentClusterLocations.FindAsync(id);
            _context.AgentClusterLocations.Remove(agentClusterLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentClusterLocationExists(int id)
        {
            return _context.AgentClusterLocations.Any(e => e.AgentClusterLocationId == id);
        }
    }
}
