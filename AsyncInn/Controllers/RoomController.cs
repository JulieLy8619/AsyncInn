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

        /// <summary>
        /// sets up the database
        /// </summary>
        /// <param name="context">the db</param>
        public RoomController(IRoomMgmt context)
        {
            _context = context;
        }

        // GET: Room
        /// <summary>
        /// calls the main page
        /// </summary>
        /// <param name="searchString">a way to filter the objects</param>
        /// <returns>the page</returns>
        public async Task<IActionResult> Index(string searchString)
        {
            return View(await _context.SearchRoom(searchString));
        }

        // GET: Room/Details/5
        /// <summary>
        /// calls the details page
        /// </summary>
        /// <param name="id">which room</param>
        /// <returns>the page</returns>
        public async Task<IActionResult> Details(int id)
        {
            var roomsD = await _context.GetRoom(id);

            return View(roomsD);
        }

        // GET: Room/Create
        /// <summary>
        /// calls the create page
        /// </summary>
        /// <returns>the page</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// makes a request to the db to add a room
        /// </summary>
        /// <param name="room">the room object</param>
        /// <returns>all the room objects</returns>
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
        /// <summary>
        /// makes a call for the edits page
        /// </summary>
        /// <param name="id">which room</param>
        /// <returns>the page</returns>
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
        /// <summary>
        /// makes a call to the database to update a record
        /// </summary>
        /// <param name="id">which room</param>
        /// <param name="room">the room object you would like to update it with</param>
        /// <returns>the list</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Layout")] Room room)
        {
            await _context.UpdateRoom(room);
            return RedirectToAction(nameof(Index));
        }

        // GET: Room/Delete/5
        /// <summary>
        /// calls the delete page
        /// </summary>
        /// <param name="id">which room</param>
        /// <returns>the page</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var delRoom = await _context.GetRoom(id);
            return View(delRoom);
        }

        // POST: Room/Delete/5
        /// <summary>
        /// makes a call to the db to remove it 
        /// </summary>
        /// <param name="id">which room</param>
        /// <returns>the remain objects</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rm = await _context.DeleteRoom(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// checks if the room is in the db
        /// </summary>
        /// <param name="id">which room</param>
        /// <returns>true or false</returns>
        private bool RoomExists(int id)
        {
            var returnedRoomId = _context.GetRoom(id);
            if (returnedRoomId.Id == id)
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
