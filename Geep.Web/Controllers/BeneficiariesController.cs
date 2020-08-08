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
    public class BeneficiariesController : Controller
    {
        private readonly GeepDbContext _context;

        public BeneficiariesController(GeepDbContext context)
        {
            _context = context;
        }

        // GET: Beneficiaries
        public async Task<IActionResult> Index()
        {
            var geepDbContext = _context.Beneficiaries.Include(b => b.ClusterLocation).Include(b => b.association);
            return View(await geepDbContext.ToListAsync());
        }

        // GET: Beneficiaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiary = await _context.Beneficiaries
                .Include(b => b.ClusterLocation)
                .Include(b => b.association)
                .FirstOrDefaultAsync(m => m.BeneficiaryId == id);
            if (beneficiary == null)
            {
                return NotFound();
            }

            return View(beneficiary);
        }

        // GET: Beneficiaries/Create
        public IActionResult Create()
        {
            ViewData["ClusterLocationId"] = new SelectList(_context.ClusterLocations, "ClusterLocationId", "ClusterLocationId");
            ViewData["AssociationId"] = new SelectList(_context.Associations, "AssociationId", "AssociationId");
            return View();
        }

        // POST: Beneficiaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BeneficiaryId,ReferenceId,ClusterLocationId,TreadeTypeId,TradeSubType,AgentId,CurrentProgramId,AssociationId,FirstName,LastName,MiddleName,Gender,DateOfBirth,PhoneNumber,BVN,HomeAddress,CurrendBankId,AccountNumber,GPS,FacialPicture,Picture,SmileIdZip,Disability,SmileReference,DateEnumerated,NextOfKinAddress,NextOfKinPhone,GuarantorFirstName,GuarantoLastName,GuarantorFirstPhone,IdCardNumber,NextOfKinName,GeopoliticalId,CreatedBy,DateCreated,DateUpdated,UpdatedBy")] Beneficiary beneficiary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beneficiary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClusterLocationId"] = new SelectList(_context.ClusterLocations, "ClusterLocationId", "ClusterLocationId", beneficiary.ClusterLocationId);
            ViewData["AssociationId"] = new SelectList(_context.Associations, "AssociationId", "AssociationId", beneficiary.AssociationId);
            return View(beneficiary);
        }

        // GET: Beneficiaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiary = await _context.Beneficiaries.FindAsync(id);
            if (beneficiary == null)
            {
                return NotFound();
            }
            ViewData["ClusterLocationId"] = new SelectList(_context.ClusterLocations, "ClusterLocationId", "ClusterLocationId", beneficiary.ClusterLocationId);
            ViewData["AssociationId"] = new SelectList(_context.Associations, "AssociationId", "AssociationId", beneficiary.AssociationId);
            return View(beneficiary);
        }

        // POST: Beneficiaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BeneficiaryId,ReferenceId,ClusterLocationId,TreadeTypeId,TradeSubType,AgentId,CurrentProgramId,AssociationId,FirstName,LastName,MiddleName,Gender,DateOfBirth,PhoneNumber,BVN,HomeAddress,CurrendBankId,AccountNumber,GPS,FacialPicture,Picture,SmileIdZip,Disability,SmileReference,DateEnumerated,NextOfKinAddress,NextOfKinPhone,GuarantorFirstName,GuarantoLastName,GuarantorFirstPhone,IdCardNumber,NextOfKinName,GeopoliticalId,CreatedBy,DateCreated,DateUpdated,UpdatedBy")] Beneficiary beneficiary)
        {
            if (id != beneficiary.BeneficiaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficiary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeneficiaryExists(beneficiary.BeneficiaryId))
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
            ViewData["ClusterLocationId"] = new SelectList(_context.ClusterLocations, "ClusterLocationId", "ClusterLocationId", beneficiary.ClusterLocationId);
            ViewData["AssociationId"] = new SelectList(_context.Associations, "AssociationId", "AssociationId", beneficiary.AssociationId);
            return View(beneficiary);
        }

        // GET: Beneficiaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiary = await _context.Beneficiaries
                .Include(b => b.ClusterLocation)
                .Include(b => b.association)
                .FirstOrDefaultAsync(m => m.BeneficiaryId == id);
            if (beneficiary == null)
            {
                return NotFound();
            }

            return View(beneficiary);
        }

        // POST: Beneficiaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beneficiary = await _context.Beneficiaries.FindAsync(id);
            _context.Beneficiaries.Remove(beneficiary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeneficiaryExists(int id)
        {
            return _context.Beneficiaries.Any(e => e.BeneficiaryId == id);
        }
    }
}
