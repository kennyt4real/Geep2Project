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
    public class AssociationBeneficiariesController : Controller
    {
        private readonly GeepDbContext _context;

        public AssociationBeneficiariesController(GeepDbContext context)
        {
            _context = context;
        }

        // GET: AssociationBeneficiaries
        public async Task<IActionResult> Index()
        {
            var geepDbContext = _context.AssociationBeneficiaries.Include(a => a.Association).Include(a => a.Beneficiary);
            return View(await geepDbContext.ToListAsync());
        }

        // GET: AssociationBeneficiaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationBeneficiary = await _context.AssociationBeneficiaries
                .Include(a => a.Association)
                .Include(a => a.Beneficiary)
                .FirstOrDefaultAsync(m => m.AssociationBeneficiaryId == id);
            if (associationBeneficiary == null)
            {
                return NotFound();
            }

            return View(associationBeneficiary);
        }

        // GET: AssociationBeneficiaries/Create
        public IActionResult Create()
        {
            ViewData["AssociationId"] = new SelectList(_context.Associations, "AssociationId", "AssociationId");
            ViewData["BeneficiaryId"] = new SelectList(_context.Beneficiaries, "BeneficiaryId", "BeneficiaryId");
            return View();
        }

        // POST: AssociationBeneficiaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssociationBeneficiaryId,AssociationId,BeneficiaryId,CreatedBy,DateCreated,DateUpdated,UpdatedBy")] AssociationBeneficiary associationBeneficiary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associationBeneficiary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociationId"] = new SelectList(_context.Associations, "AssociationId", "AssociationId", associationBeneficiary.AssociationId);
            ViewData["BeneficiaryId"] = new SelectList(_context.Beneficiaries, "BeneficiaryId", "BeneficiaryId", associationBeneficiary.BeneficiaryId);
            return View(associationBeneficiary);
        }

        // GET: AssociationBeneficiaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationBeneficiary = await _context.AssociationBeneficiaries.FindAsync(id);
            if (associationBeneficiary == null)
            {
                return NotFound();
            }
            ViewData["AssociationId"] = new SelectList(_context.Associations, "AssociationId", "AssociationId", associationBeneficiary.AssociationId);
            ViewData["BeneficiaryId"] = new SelectList(_context.Beneficiaries, "BeneficiaryId", "BeneficiaryId", associationBeneficiary.BeneficiaryId);
            return View(associationBeneficiary);
        }

        // POST: AssociationBeneficiaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssociationBeneficiaryId,AssociationId,BeneficiaryId,CreatedBy,DateCreated,DateUpdated,UpdatedBy")] AssociationBeneficiary associationBeneficiary)
        {
            if (id != associationBeneficiary.AssociationBeneficiaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associationBeneficiary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociationBeneficiaryExists(associationBeneficiary.AssociationBeneficiaryId))
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
            ViewData["AssociationId"] = new SelectList(_context.Associations, "AssociationId", "AssociationId", associationBeneficiary.AssociationId);
            ViewData["BeneficiaryId"] = new SelectList(_context.Beneficiaries, "BeneficiaryId", "BeneficiaryId", associationBeneficiary.BeneficiaryId);
            return View(associationBeneficiary);
        }

        // GET: AssociationBeneficiaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associationBeneficiary = await _context.AssociationBeneficiaries
                .Include(a => a.Association)
                .Include(a => a.Beneficiary)
                .FirstOrDefaultAsync(m => m.AssociationBeneficiaryId == id);
            if (associationBeneficiary == null)
            {
                return NotFound();
            }

            return View(associationBeneficiary);
        }

        // POST: AssociationBeneficiaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var associationBeneficiary = await _context.AssociationBeneficiaries.FindAsync(id);
            _context.AssociationBeneficiaries.Remove(associationBeneficiary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociationBeneficiaryExists(int id)
        {
            return _context.AssociationBeneficiaries.Any(e => e.AssociationBeneficiaryId == id);
        }
    }
}
