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

        /// <summary>
        /// helps give access to the database through dependency injection
        /// </summary>
        /// <param name="context">dependency injection</param>
        public AmenitiesController(IAmenitiesMgmt context)
        {
            _context = context;
        }

        // GET: Amenities
        /// <summary>
        /// Calls the main page for Amenities
        /// </summary>
        /// <param name="searchString">search params to filter the query</param>
        /// <returns>the objects to display to the page</returns>
        public async Task<IActionResult> Index(string searchString)
        {
            return View(await _context.SearchAmenity(searchString));
        }

        // GET: Amenities/Details/5
        /// <summary>
        /// Calls the details page for Amenities
        /// </summary>
        /// <param name="id">the id of which amenity</param>
        /// <returns>the details of that amenity</returns>
        public async Task<IActionResult> Details(int id)
        {
            var amenities = await _context.GetAmenities(id);

            return View(amenities);
        }

        // GET: Amenities/Create
        /// <summary>
        /// calls the page to create a new amenity
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Sends request to the DB to make a new Amenity
        /// </summary>
        /// <param name="amenities">the new amenity object</param>
        /// <returns>the amenities</returns>
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
        /// <summary>
        /// Calls the page to update an amenity
        /// </summary>
        /// <param name="id">which amenity</param>
        /// <returns>the amenites</returns>
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
        /// <summary>
        /// Send the details of what to update the amenity with
        /// </summary>
        /// <param name="id">the amenity adjustments</param>
        /// <param name="amenities"></param>
        /// <returns>teh amenities</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenities amenities)
        {
            await _context.UpdateAmenity(amenities);
            return RedirectToAction(nameof(Index));
        }

        // GET: Amenities/Delete/5
        /// <summary>
        /// Calls the delete page for amenities
        /// </summary>
        /// <param name="id">which amenity one wants to delete</param>
        /// <returns>the amenity</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var delAmenity = await _context.GetAmenities(id);
            return View(delAmenity);

        }

        // POST: Amenities/Delete/5
        /// <summary>
        /// Sends the details of what to delete from the DB
        /// </summary>
        /// <param name="id">which amenity</param>
        /// <returns>the amenities</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amenities = await _context.DeleteAmenity(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// checks if an amenity exists in the DB
        /// </summary>
        /// <param name="id">which amenity</param>
        /// <returns>true or false</returns>
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
