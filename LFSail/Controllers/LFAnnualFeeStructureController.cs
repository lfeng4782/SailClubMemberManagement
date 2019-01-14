

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LFSail.Models;
using Microsoft.EntityFrameworkCore;


namespace LFSail.Controllers
{
    public class LFAnnualFeeStructureController : Controller
    {
        private readonly SailContext _context;

        public LFAnnualFeeStructureController(SailContext context)
        {
            _context = context;
        }

        // GET: LFAnnualFeeStructure
        // Display year and annualFee fields, and order the record by year
        public async Task<IActionResult> Index()
        {
            var annualFee = await _context.AnnualFeeStructure
                .OrderByDescending(y=>y.Year)
                .ToListAsync();
            return View(annualFee);
        }

        // GET: LFAnnualFeeStructure/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annualFeeStructure = await _context.AnnualFeeStructure
                .FirstOrDefaultAsync(m => m.Year == id);
            if (annualFeeStructure == null)
            {
                return NotFound();
            }

            return View(annualFeeStructure);
        }

        // GET: LFAnnualFeeStructure/Create
        // Preload the data from the most recent record
        // Overlay the year with current year
        public async Task<IActionResult> Create()
        {
            var mostRecentRecord = await _context.AnnualFeeStructure
                .OrderByDescending(y => y.Year)
                .FirstOrDefaultAsync();        

            ViewBag.Year = DateTime.Now.Year.ToString();

            return View(mostRecentRecord);
        }

            // POST: LFAnnualFeeStructure/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Year,AnnualFee,EarlyDiscountedFee,EarlyDiscountEndDate,RenewDeadlineDate,TaskExemptionFee,SecondBoatFee,ThirdBoatFee,ForthAndSubsequentBoatFee,NonSailFee,NewMember25DiscountDate,NewMember50DiscountDate,NewMember75DiscountDate")] AnnualFeeStructure annualFeeStructure)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(annualFeeStructure);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index)); 
                }
                return View(annualFeeStructure);
            }
            catch (Exception)
            {
                TempData["message"] = "Please check fileds for errors.";
                return View(annualFeeStructure);
            }
           
        }

        // GET: LFAnnualFeeStructure/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annualFeeStructure = await _context.AnnualFeeStructure.FindAsync(id);
            if (annualFeeStructure == null)
            {
                return NotFound();
            }

           return View(annualFeeStructure);
        }

        // POST: LFAnnualFeeStructure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Year,AnnualFee,EarlyDiscountedFee,EarlyDiscountEndDate,RenewDeadlineDate,TaskExemptionFee,SecondBoatFee,ThirdBoatFee,ForthAndSubsequentBoatFee,NonSailFee,NewMember25DiscountDate,NewMember50DiscountDate,NewMember75DiscountDate")] AnnualFeeStructure annualFeeStructure)
        {
            if (id != annualFeeStructure.Year)
            {
                return NotFound();
            }

            if (id<DateTime.Now.Year)
            {
                TempData["message"] = "You can not edit the prior year's record";
                return RedirectToAction(nameof(Index));               
            }                       
                    
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(annualFeeStructure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnualFeeStructureExists(annualFeeStructure.Year))
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
            return View(annualFeeStructure);
        }

        // GET: LFAnnualFeeStructure/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annualFeeStructure = await _context.AnnualFeeStructure
                .FirstOrDefaultAsync(m => m.Year == id);
            if (annualFeeStructure == null)
            {
                return NotFound();
            }

            return View(annualFeeStructure);
        }

        // POST: LFAnnualFeeStructure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var annualFeeStructure = await _context.AnnualFeeStructure.FindAsync(id);
            _context.AnnualFeeStructure.Remove(annualFeeStructure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnualFeeStructureExists(int id)
        {
            return _context.AnnualFeeStructure.Any(e => e.Year == id);
        }
    }
}
