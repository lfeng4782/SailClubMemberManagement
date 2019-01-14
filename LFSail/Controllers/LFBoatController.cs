
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
    public class LFBoatController : Controller
    {
        private readonly SailContext _context;

        public LFBoatController(SailContext context)
        {
            _context = context;
        }

        // GET: LFBoat
        public async Task<IActionResult> Index(int? memberId)
        {
            if (memberId != null)
            {
                HttpContext.Session.SetInt32("MemberId",Convert.ToInt32(memberId));
            }
            else if (memberId == null)
            {
                if (HttpContext.Session.GetInt32("MemberId") != null)
                {
                    memberId = HttpContext.Session.GetInt32("MemberId");
                }
                else
                {
                    TempData["message"] = "Please select a member to see his/her boats.";
                    return RedirectToAction("Index", "LFMember");
                }
            }
            var fullname =  _context.Member
                .Where(x => x.MemberId == memberId)
                .FirstOrDefault();

            ViewBag.FullName = fullname.FullName;

            var sailContext = _context.Boat.OrderBy(x=>x.BoatClass).Where(x=>x.MemberId==memberId).Include(b => b.BoatType).Include(b => b.Member).Include(b => b.ParkingCodeNavigation);
            return View(await sailContext.ToListAsync());
        }

        // GET: LFBoat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var memberId = HttpContext.Session.GetInt32("MemberId");
            var fullname = _context.Member
                .Where(x => x.MemberId == memberId)
                .FirstOrDefault();

            ViewBag.FullName = fullname.FullName;
            if (id == null)
            {
                return NotFound();
            }

            var boat = await _context.Boat
                .Include(b => b.BoatType)
                .Include(b => b.Member)
                .Include(b => b.ParkingCodeNavigation)
                .FirstOrDefaultAsync(m => m.BoatId == id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // GET: LFBoat/Create
        public IActionResult Create()
        {
            int? memberId = HttpContext.Session.GetInt32("MemberId");
            var fullname = _context.Member
                .Where(x => x.MemberId == memberId)
                .FirstOrDefault();

            ViewBag.FullName = fullname.FullName;
           // get already occupied parking code
            var occupiedParkingCode = _context.Boat
                .Where(x => x.ParkingCode != "")
                .Select(x => x.ParkingCode)
                .ToList();
            // availabe parking code
            var availableParkingCode = _context.Parking
                .Where(x => !occupiedParkingCode.Contains(x.ParkingCode));

            // add empty entry             
            availableParkingCode.FirstOrDefault().ParkingCode = null;
            
            ViewData["BoatTypeId"] = new SelectList(_context.BoatType.OrderBy(x=>x.Name), "BoatTypeId", "Name");
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "FirstName");
            ViewData["ParkingCode"] = new SelectList(availableParkingCode, "ParkingCode","ParkingCode");
            return View();
        }

        // POST: LFBoat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BoatId,MemberId,BoatClass,HullColour,SailNumber,HullLength,BoatTypeId,ParkingCode")] Boat boat)
        {
            boat.MemberId = HttpContext.Session.GetInt32("MemberId");
            var fullname = _context.Member
                .Where(x => x.MemberId == boat.MemberId)
                .FirstOrDefault();

            ViewBag.FullName = fullname.FullName;
            if (ModelState.IsValid)
            {
                _context.Add(boat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoatTypeId"] = new SelectList(_context.BoatType.OrderBy(x => x.Name), "BoatTypeId", "Name", boat.BoatTypeId);
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "FirstName", boat.MemberId);
            ViewData["ParkingCode"] = new SelectList(_context.Parking, "ParkingCode", "ParkingCode", boat.ParkingCode);
            return View(boat);
        }

        // GET: LFBoat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var memberId = HttpContext.Session.GetInt32("MemberId");
            var fullname = _context.Member
                .Where(x => x.MemberId == memberId)
                .FirstOrDefault();

            ViewBag.FullName = fullname.FullName;
            if (id == null)
            {
                return NotFound();
            }

            var boat = await _context.Boat.FindAsync(id);
            if (boat == null)
            {
                return NotFound();
            }

            // get already occupied parking code
            var occupiedParkingCode = _context.Boat
                .Where(x => x.ParkingCode != "")
                .Select(x => x.ParkingCode)
                .ToList();
            // availabe parking code
            var availableParkingCode = _context.Parking
                .Where(x => !occupiedParkingCode.Contains(x.ParkingCode))
                .Where(x=>x.BoatTypeId==boat.BoatTypeId);

            ViewData["BoatTypeId"] = new SelectList(_context.BoatType.OrderBy(x => x.Name), "BoatTypeId", "Name", boat.BoatTypeId);
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "FirstName", boat.MemberId);
            ViewData["ParkingCode"] = new SelectList(availableParkingCode, "ParkingCode", "ParkingCode", boat.ParkingCode);
            return View(boat);
        }

        // POST: LFBoat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BoatId,MemberId,BoatClass,HullColour,SailNumber,HullLength,BoatTypeId,ParkingCode")] Boat boat)
        {
            boat.MemberId = HttpContext.Session.GetInt32("MemberId");
            var fullname = _context.Member
                .Where(x => x.MemberId == boat.MemberId)
                .FirstOrDefault();

            ViewBag.FullName = fullname.FullName;

            if (id != boat.BoatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoatExists(boat.BoatId))
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
            ViewData["BoatTypeId"] = new SelectList(_context.BoatType.OrderBy(x => x.Name), "BoatTypeId", "Name", boat.BoatTypeId);
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "FirstName", boat.MemberId);
            ViewData["ParkingCode"] = new SelectList(_context.Parking, "ParkingCode", "ParkingCode", boat.ParkingCode);
            return View(boat);
        }

        // GET: LFBoat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var memberId =  HttpContext.Session.GetInt32("MemberId");
            var fullname = _context.Member
                .Where(x => x.MemberId == memberId)
                .FirstOrDefault();

            ViewBag.FullName = fullname.FullName;

            if (id == null)
            {
                return NotFound();
            }

            var boat = await _context.Boat
                .Include(b => b.BoatType)
                .Include(b => b.Member)
                .Include(b => b.ParkingCodeNavigation)
                .FirstOrDefaultAsync(m => m.BoatId == id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // POST: LFBoat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var memberId = HttpContext.Session.GetInt32("MemberId");

            var fullname = _context.Member
                .Where(x => x.MemberId ==memberId)
                .FirstOrDefault();

            ViewBag.FullName = fullname.FullName;

            var boat = await _context.Boat.FindAsync(id);
            _context.Boat.Remove(boat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoatExists(int id)
        {
            return _context.Boat.Any(e => e.BoatId == id);
        }
    }
}
