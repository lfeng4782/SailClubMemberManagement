

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LFSail.Models;
using Microsoft.AspNetCore.Http;

namespace LFSail.Controllers
{
    public class LFMembershipController : Controller
    {
        private readonly SailContext _context;

        public LFMembershipController(SailContext context)
        {
            _context = context;
        }

        // GET: LFMembership
        // Display membership record for one specific member 
        // Order by year
        public async Task<IActionResult> Index(int? memberId, string fullName)
        {
            //a.If the memberId is in the URL or a QueryString variable, 
            //save it to a cookie or session variable.
            if (memberId!= null && fullName!=null)
            {
                HttpContext.Session.SetInt32("MemberId", memberId.GetValueOrDefault());
                HttpContext.Session.SetString("FullName", fullName);
                var membership = await _context.Membership
                 .Include(m => m.Member)
                 .Include(m => m.MembershipTypeNameNavigation)
                 .Where(m => m.MemberId == memberId)
                 .OrderByDescending(m => m.Year)
                 .ToListAsync();
                return View(membership);
            }
           // b.If there is no memberId passed in the URL or QueryString,
           //see if there’s a cookie or session variable with it.
            else if (HttpContext.Session.GetInt32("MemberId") != null && HttpContext.Session.GetString("FullName") != null)
            {
                memberId = HttpContext.Session.GetInt32("MemberId");
                var membership = await _context.Membership
                 .Include(m => m.Member)
                 .Include(m => m.MembershipTypeNameNavigation)
                 .Where(m => m.MemberId == memberId)
                 .OrderByDescending(m => m.Year)
                 .ToListAsync();
                return View(membership);
            }
            //i.If there’s no memberId in the cookie or session variables either, 
            //return to the XXMember controller with a message asking them to 
            //select a member to see its memberships.
            else
            {
                TempData["message"] = "Please select a member.";
                return RedirectToAction("index", "LFMember");
            }                   
        }

        // GET: LFMembership/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Membership
                .Include(m => m.Member)
                .Include(m => m.MembershipTypeNameNavigation)
                .FirstOrDefaultAsync(m => m.MembershipId == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // GET: LFMembership/Create
        // In the membershipType drop-down, display and return
        //the membershipTypeName (that’s its primary key), in ascending order
        public IActionResult Create()
        {
    
            ViewBag.Year = DateTime.Now.Year.ToString();

            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "FirstName");
            ViewData["MembershipTypeName"] = new SelectList(_context.MembershipType.OrderBy(x=>x.MembershipTypeName), "MembershipTypeName", "MembershipTypeName");
            
            return View();
        }

        // POST: LFMembership/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembershipId,MemberId,Year,MembershipTypeName,Fee,Comments,Paid")] Membership membership)
        {     
            // Get Memberid from session
            membership.MemberId = HttpContext.Session.GetInt32("MemberId").GetValueOrDefault();

            if (ModelState.IsValid)
            {                
                // this is getting raw data from the DB (AnnualFeeStructure table)
                var annualFee = await _context.AnnualFeeStructure
                .OrderByDescending(x => x.Year)
                .FirstOrDefaultAsync();
                var membershipType = await _context.MembershipType.Where(x => x.MembershipTypeName==membership.MembershipTypeName).FirstOrDefaultAsync();
                var boatNumber = _context.Boat.Where(x=>x.MemberId== membership.MemberId).Count();

                double boatFee = 0;

                // check boatFee with boat numbers
                if (boatNumber <= 1)
                {
                    boatFee = (double)annualFee.NonSailFee;
                }
                else if (boatNumber == 2)
                {
                    boatFee = (double)(annualFee.NonSailFee + annualFee.SecondBoatFee);
                }
                else if (boatNumber == 3)
                {
                    boatFee = (double)(annualFee.NonSailFee + annualFee.SecondBoatFee + annualFee.ThirdBoatFee);
                }

                else if (boatNumber > 3)
                {
                    boatFee = (double)(annualFee.NonSailFee + annualFee.SecondBoatFee + annualFee.ThirdBoatFee + annualFee.ForthAndSubsequentBoatFee);
                }                                
                
                // modify "membership.Fee" to calculae the actual fee
                membership.Fee =(float)(boatFee + annualFee.AnnualFee * membershipType.RatioToFull);
                
                // add to database
                _context.Add(membership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));                
            }
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "FirstName", membership.MemberId);
            ViewData["MembershipTypeName"] = new SelectList(_context.MembershipType.OrderBy(x => x.MembershipTypeName), "MembershipTypeName", "MembershipTypeName", membership.MembershipTypeName);
            
            return View(membership);
        }

        // GET: LFMembership/Edit/5
        // In the membershipType drop-down, display and return
        // the membershipTypeName (that’s its primary key), in ascending order
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }            
            
            var membership = await _context.Membership.FindAsync(id);
            if (membership == null)
            {
                return NotFound();
            }
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "FirstName", membership.MemberId);
            ViewData["MembershipTypeName"] = new SelectList(_context.MembershipType.OrderBy(x=>x.MembershipTypeName), "MembershipTypeName", "MembershipTypeName", membership.MembershipTypeName);
            
            return View(membership);
        }

        // POST: LFMembership/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembershipId,MemberId,Year,MembershipTypeName,Fee,Comments,Paid")] Membership membership)
        {
            
            if (id != membership.MembershipId)
            {
                return NotFound();
            }
           
            if (membership.Year < DateTime.Now.Year)
            {
                TempData["message"] = "You can not edit the prior year's record";
                return RedirectToAction(nameof(Index));               
            }

            if (ModelState.IsValid)
            {
                try
                {                    
                    _context.Update(membership);
                    await _context.SaveChangesAsync();                    
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershipExists(membership.MembershipId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "FirstName", membership.MemberId);
            ViewData["MembershipTypeName"] = new SelectList(_context.MembershipType.OrderBy(x => x.MembershipTypeName), "MembershipTypeName", "MembershipTypeName", membership.MembershipTypeName);
            return View(membership);
        }

        // GET: LFMembership/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Membership
                .Include(m => m.Member)
                .Include(m => m.MembershipTypeNameNavigation)
                .FirstOrDefaultAsync(m => m.MembershipId == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // POST: LFMembership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membership = await _context.Membership.FindAsync(id);
            _context.Membership.Remove(membership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));           
        }

        private bool MembershipExists(int id)
        {
            return _context.Membership.Any(e => e.MembershipId == id);
        }
    }
}
