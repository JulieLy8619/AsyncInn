using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    public class AmenitiesController : Controller
    {
        private readonly IAmenitiesMgmt _context;

        public AmenitiesController(IAmenitiesMgmt context)
        {
            _context = context;
        }

        // GET: Amenities
        public async Task<IActionResult> Index(string id)
        {
            return View(await _context.SearchAmenity(id));
        }

        // GET: Amenities/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var amenities = await _context.GetAmenities(id);

            return View(amenities);
        }

        // GET: Amenities/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amenities amenities)
        {
            Amenities newAmend = amenities;
            if (ModelState.IsValid)
            {
                await _context.CreateAmenity(newAmend);
                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var amenities = await _context.GetAmenities(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        //// POST: Amenities/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenities amenities)
        {
            await _context.UpdateAmenity(amenities);
            return RedirectToAction(nameof(Index));
        }

        // GET: Amenities/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var delAmenity = await _context.GetAmenities(id);
            return View(delAmenity);

        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amenities = await _context.DeleteAmenity(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AmenitiesExists(int id)
        {
            var returnedAmenityId = _context.GetAmenities(id);
            if (returnedAmenityId.Id == id)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
