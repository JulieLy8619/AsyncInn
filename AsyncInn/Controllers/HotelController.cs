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
    public class HotelController : Controller
    {
        private readonly IHotelMgmt _context;

        public HotelController(IHotelMgmt context)
        {
            _context = context;
        }

        // GET: Hotel
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetHotel());
        }

        // GET: Hotel/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var hotels = await _context.GetHotel(id);

            return View(hotels);
        }

        // GET: Hotel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,PhoneNumber")] Hotel hotel)
        {
            Hotel newHotel = hotel;
            if (ModelState.IsValid)
            {
                await _context.CreateHotel(newHotel);
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotel/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var hotel = await _context.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        //// POST: Hotel/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,PhoneNumber")] Hotel hotel)
        //{
        //    if (id != hotel.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(hotel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!HotelExists(hotel.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(hotel);
        //}

        // GET: Hotel/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var delHotel = await _context.GetHotel(id);
            return View(delHotel);
        }

        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.DeleteHotel(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool HotelExists(int id)
        //{
        //    return _context.HotelTable.Any(e => e.ID == id);
        //}
    }
}
