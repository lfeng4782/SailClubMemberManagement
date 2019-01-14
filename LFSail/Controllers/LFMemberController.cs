

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LFSail.Models;

namespace LFSail.Controllers
{
    public class LFMemberController : Controller
    {
        private readonly SailContext _context;

        public LFMemberController(SailContext context)
        {
            _context = context;
        }

        // GET: LFMember
        // order the listing by fullname        
        public async Task<IActionResult> Index()
        {
            var member = await _context.Member.Include(m => m.ProvinceCodeNavigation).OrderBy(m => m.FullName).ToListAsync();
            
            return View(member);
        }



        // GET: LFMember/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .Include(m => m.ProvinceCodeNavigation)
                .FirstOrDefaultAsync(m => m.MemberId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: LFMember/Create
        public IActionResult Create()
        {
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "ProvinceCode", "ProvinceCode");
            return View();
        }

        // POST: LFMember/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberId,FullName,FirstName,LastName,SpouseFirstName,SpouseLastName,Street,City,ProvinceCode,PostalCode,HomePhone,Email,YearJoined,Comment,TaskExempt,UseCanadaPost")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "ProvinceCode", "ProvinceCode", member.ProvinceCode);
            return View(member);
        }

        // GET: LFMember/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "ProvinceCode", "ProvinceCode", member.ProvinceCode);
            return View(member);
        }

        // POST: LFMember/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,FullName,FirstName,LastName,SpouseFirstName,SpouseLastName,Street,City,ProvinceCode,PostalCode,HomePhone,Email,YearJoined,Comment,TaskExempt,UseCanadaPost")] Member member)
        {
            if (id != member.MemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.MemberId))
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
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "ProvinceCode", "ProvinceCode", member.ProvinceCode);
            return View(member);
        }

        // GET: LFMember/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .Include(m => m.ProvinceCodeNavigation)
                .FirstOrDefaultAsync(m => m.MemberId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: LFMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Member.FindAsync(id);
            _context.Member.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.MemberId == id);
        }
    }
}
