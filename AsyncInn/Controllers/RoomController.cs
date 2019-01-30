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
    public class RoomController : Controller
    {
        private readonly IRoomMgmt _context;

        public RoomController(IRoomMgmt context)
        {
            _context = context;
        }

        // GET: Room
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetRoom());
        }

        // GET: Room/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var roomsD = await _context.GetRoom(id);

            return View(roomsD);
        }

        // GET: Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Layout")] Room room)
        {
            Room newRm = room;
            if (ModelState.IsValid)
            {
                await _context.CreateRoom(newRm);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var rm = await _context.GetRoom(id);
            if (rm == null)
            {
                return NotFound();
            }
            return View(rm);
        }

        //// POST: Room/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Layout")] Room room)
        //{
        //    if (id != room.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(room);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RoomExists(room.ID))
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
        //    return View(room);
        //}

        // GET: Room/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var delRoom = await _context.GetRoom(id);
            return View(delRoom);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rm = await _context.DeleteRoom(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool RoomExists(int id)
        //{
        //    return _context.RoomTable.Any(e => e.ID == id);
        //}
    }
}
