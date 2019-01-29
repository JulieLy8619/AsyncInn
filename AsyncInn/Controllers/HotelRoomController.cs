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

        public HotelRoomController(HotelMgmtDBContext context)
        {
            _context = context;
        }

        // GET: HotelRoom
        public async Task<IActionResult> Index()
        {
            var hotelMgmtDBContext = _context.HotelRoomTable.Include(h => h.Hotel).Include(h => h.Room);
            return View(await hotelMgmtDBContext.ToListAsync());
        }

        // GET: HotelRoom/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRoomTable
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // GET: HotelRoom/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.HotelTable, "ID", "Name");
            ViewData["RoomNumber"] = new SelectList(_context.RoomTable, "RoomNumber", "RoomNumber");
            return View();
        }

        // POST: HotelRoom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.HotelTable, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomNumber"] = new SelectList(_context.RoomTable, "RoomNumber", "RoomNumber", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRoom/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRoomTable.FindAsync(id);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.HotelTable, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomNumber"] = new SelectList(_context.RoomTable, "RoomNumber", "RoomNumber", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // POST: HotelRoom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (id != hotelRoom.HotelID)
            {
                return NotFound();
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
            ViewData["RoomNumber"] = new SelectList(_context.RoomTable, "RoomNumber", "RoomNumber", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRoom/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRoomTable
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: HotelRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelRoom = await _context.HotelRoomTable.FindAsync(id);
            _context.HotelRoomTable.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomExists(int id)
        {
            return _context.HotelRoomTable.Any(e => e.HotelID == id);
        }
    }
}
