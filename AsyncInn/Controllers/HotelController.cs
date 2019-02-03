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

        /// <summary>
        /// sets up the database connection
        /// </summary>
        /// <param name="context"></param>
        public HotelController(IHotelMgmt context)
        {
            _context = context;
        }

        // GET: Hotel
        /// <summary>
        /// calls the main page for hotels
        /// </summary>
        /// <param name="searchString">a key word to filter the data that is returned to the page</param>
        /// <returns>Hotel objects</returns>
        public async Task<IActionResult> Index(string searchString)
        {
            return View(await _context.SearchHotel(searchString));
        }

        // GET: Hotel/Details/5
        /// <summary>
        /// Calls the details page
        /// </summary>
        /// <param name="id">which Hotel</param>
        /// <returns>the details of the specific Hotel</returns>
        public async Task<IActionResult> Details(int id)
        {
            var hotels = await _context.GetHotel(id);

            return View(hotels);
        }

        // GET: Hotel/Create
        /// <summary>
        /// Calls the create a hotel page
        /// </summary>
        /// <returns>the page</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Sends the request to the DB to create a new Hotel
        /// </summary>
        /// <param name="hotel">The new Hotel</param>
        /// <returns>the hotels</returns>
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
        /// <summary>
        /// calls the edit page
        /// </summary>
        /// <param name="id">which hotel</param>
        /// <returns>the page where you can inut the changes</returns>
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
        /// <summary>
        /// Sends the request to the DB to update a hotel
        /// </summary>
        /// <param name="id">which hotel</param>
        /// <param name="hotel">the information you are updating</param>
        /// <returns>teh hotels</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,PhoneNumber")] Hotel hotel)
        {
            await _context.UpdateHotel(hotel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Hotel/Delete/5
        /// <summary>
        /// calls the delete page
        /// </summary>
        /// <param name="id">which hotel</param>
        /// <returns>the page</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var delHotel = await _context.GetHotel(id);
            return View(delHotel);
        }

        // POST: Hotel/Delete/5
        /// <summary>
        /// send the request to the DB to delete a hotel
        /// </summary>
        /// <param name="id">which hotel</param>
        /// <returns>the remaining hotels</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.DeleteHotel(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// checks the database if the hotel exists
        /// </summary>
        /// <param name="id">which hotel</param>
        /// <returns>true or false</returns>
        private bool HotelExists(int id)
        {
            var returnedHotelId = _context.GetHotel(id);
            if (returnedHotelId.Id == id)
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
