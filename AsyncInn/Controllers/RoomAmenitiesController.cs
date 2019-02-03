using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
    public class RoomAmenitiesController : Controller
    {
        private readonly HotelMgmtDBContext _context;

        /// <summary>
        /// sets up the db
        /// </summary>
        /// <param name="context">the db</param>
        public RoomAmenitiesController(HotelMgmtDBContext context)
        {
            _context = context;
        }

        // GET: RoomAmenities
        /// <summary>
        /// calls the main page
        /// </summary>
        /// <returns>the page</returns>
        public async Task<IActionResult> Index()
        {
            var hotelMgmtDBContext = _context.RoomAmenitiesTable.Include(r => r.Amenities).Include(r => r.Room);
            return View(await hotelMgmtDBContext.ToListAsync());
        }

        // GET: RoomAmenities/Details/5
        /// <summary>
        /// calls the details page
        /// </summary>
        /// <param name="RoomID">which room</param>
        /// <param name="AmenitiesID">which amenity</param>
        /// <returns>the page</returns>
        public async Task<IActionResult> Details(int? RoomID, int? AmenitiesID)
        {
            if (RoomID == null )
            {
                return NotFound();
            }

            var roomAmenities = await _context.RoomAmenitiesTable
                .Include(r => r.Amenities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomID == RoomID);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        // GET: RoomAmenities/Create
        /// <summary>
        /// calls the create page
        /// </summary>
        /// <returns>the page</returns>
        public IActionResult Create()
        {
            ViewData["AmenitiesID"] = new SelectList(_context.AmenitiesTable, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.RoomTable, "ID", "Name");
            return View();
        }

        // POST: RoomAmenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// makes a request to the db to add a room amenity
        /// </summary>
        /// <param name="roomAmenities">what is the new room amenity</param>
        /// <returns>the room amenities</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmenitiesID,RoomID")] RoomAmenities roomAmenities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomAmenities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenitiesID"] = new SelectList(_context.AmenitiesTable, "ID", "Name", roomAmenities.AmenitiesID);
            ViewData["RoomID"] = new SelectList(_context.RoomTable, "ID", "Name", roomAmenities.RoomID);
            return View(roomAmenities);
        }

        // GET: RoomAmenities/Delete/5
        /// <summary>
        /// calls the delete page
        /// </summary>
        /// <param name="RoomID">which room</param>
        /// <param name="AmenitiesID">which amenity</param>
        /// <returns>the page</returns>
        public async Task<IActionResult> Delete(int? RoomID, int? AmenitiesID)
        {
            if (RoomID == null)
            {
                return NotFound();
            }

            var roomAmenities = await _context.RoomAmenitiesTable
                .Include(r => r.Amenities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomID == RoomID);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        // POST: RoomAmenities/Delete/5
        /// <summary>
        /// makes a request to the db to remove it 
        /// </summary>
        /// <param name="RoomID">which room</param>
        /// <param name="AmenitiesID">which amenity</param>
        /// <returns>the remining room amenities</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int RoomID, int AmenitiesID)
        {
            var roomAmenities = await _context.RoomAmenitiesTable
                .Include(r => r.Amenities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomID == RoomID);
            if (roomAmenities == null)
            {
                return NotFound();
            }
            else
            {
                _context.RoomAmenitiesTable.Remove(roomAmenities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// checks if the room amenity is already in the DB
        /// </summary>
        /// <param name="id">which room amenity</param>
        /// <returns>true or false</returns>
        private bool RoomAmenitiesExists(int id)
        {
            return _context.RoomAmenitiesTable.Any(e => e.AmenitiesID == id);
        }
    }
}
