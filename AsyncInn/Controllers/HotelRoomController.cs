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
    public class HotelRoomController : Controller
    {
        private readonly HotelMgmtDBContext _context;

        /// <summary>
        /// sets up the database for hotel rooms
        /// </summary>
        /// <param name="context">database details</param>
        public HotelRoomController(HotelMgmtDBContext context)
        {
            _context = context;
        }

        // GET: HotelRoom
        /// <summary>
        /// calls the main Hotel room page
        /// </summary>
        /// <returns>the page</returns>
        public async Task<IActionResult> Index()
        {
            var hotelMgmtDBContext = _context.HotelRoomTable.Include(h => h.Hotel).Include(h => h.Room);
            return View(await hotelMgmtDBContext.ToListAsync());
        }

        // GET: HotelRoom/Details/5
        /// <summary>
        /// Calls the details page
        /// </summary>
        /// <param name="HotelID">which hotelroom</param>
        /// <param name="RoomNumber">which room number</param>
        /// <returns>the page with the details</returns>
        public async Task<IActionResult> Details(int? HotelID, int? RoomNumber)
        {
            if (HotelID == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRoomTable
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == HotelID);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // GET: HotelRoom/Create
        /// <summary>
        /// calls the create page
        /// </summary>
        /// <returns>the page to create a hotelroom</returns>
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.HotelTable, "ID", "Name");
            ViewData["RoomNumber"] = new SelectList(_context.RoomTable, "ID", "RoomNumber");
            ViewData["RoomID"] = new SelectList(_context.RoomTable, "ID", "Name");
            return View();
        }

        // POST: HotelRoom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// requests the DB to add a Hotelroom
        /// </summary>
        /// <param name="hotelRoom">the hotel room details</param>
        /// <returns>the page with the hotel rooms</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                //or should I try a linq and then if it is found in the table then return a notfound()
                try
                {
                    _context.Add(hotelRoom);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    //this does not work
                    /*Console.WriteLine("That room number was already used or you are out of range");*/
                    return NotFound();
                }
            }
            ViewData["HotelID"] = new SelectList(_context.HotelTable, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomNumber"] = new SelectList(_context.RoomTable, "ID", "RoomNumber", hotelRoom.RoomNumber);
            ViewData["RoomID"] = new SelectList(_context.RoomTable, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRoom/Edit/5
        /// <summary>
        /// gets the page to edit the hotel room
        /// </summary>
        /// <param name="HotelID">which hotel</param>
        /// <param name="RoomNumber">which hotel room number</param>
        /// <returns>the page with the details</returns>
        public async Task<IActionResult> Edit(int? HotelID, int? RoomNumber)
        {
            if (HotelID == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRoomTable
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == HotelID);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            ViewData["HotelID"] = new SelectList(_context.HotelTable, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomNumber"] = new SelectList(_context.RoomTable, "ID", "RoomNumber", hotelRoom.RoomNumber);
            ViewData["RoomID"] = new SelectList(_context.RoomTable, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // POST: HotelRoom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// makes a request to the database to update the details of the hotel room
        /// </summary>
        /// <param name="HotelID">which hotel</param>
        /// <param name="RoomNumber">which hotel room number</param>
        /// <param name="hotelRoom">the page with all the hotel rooms</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? HotelID, int? RoomNumber, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (HotelID != hotelRoom.HotelID)
            {
                return NotFound();
            }
            if(hotelRoom.RoomNumber == RoomNumber)
            {
                return RedirectToAction(nameof(Create)); //asks they try recreate
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.HotelID))
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
            ViewData["HotelID"] = new SelectList(_context.HotelTable, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomNumber"] = new SelectList(_context.RoomTable, "ID", "RoomNumber", hotelRoom.RoomNumber);
            ViewData["RoomID"] = new SelectList(_context.RoomTable, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRoom/Delete/5
        /// <summary>
        /// calls the delete page
        /// </summary>
        /// <param name="HotelID">which hotel</param>
        /// <param name="RoomNumber">which hotel room number</param>
        /// <returns>the page</returns>
        public async Task<IActionResult> Delete(int? HotelID, int? RoomNumber)
        {
            if (HotelID == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRoomTable
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == HotelID);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: HotelRoom/Delete/5
        /// <summary>
        /// makes a request to the DB to remove an hotel room
        /// </summary>
        /// <param name="HotelID">which hotel</param>
        /// <param name="RoomNumber">which room number</param>
        /// <returns>the page with the remaining objects</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int HotelID, int RoomNumber)
        {
            //if (HotelID == null)
            //{
            //    return NotFound();
            //}
            var hotelRoom = await _context.HotelRoomTable
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == HotelID && m.RoomNumber == RoomNumber);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            else
            {
                _context.HotelRoomTable.Remove(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// determines if the hotel room was in the db or not
        /// </summary>
        /// <param name="id">which hotel room</param>
        /// <returns>true or false</returns>
        private bool HotelRoomExists(int id)
        {
            return _context.HotelRoomTable.Any(e => e.HotelID == id);
        }
    }
}
