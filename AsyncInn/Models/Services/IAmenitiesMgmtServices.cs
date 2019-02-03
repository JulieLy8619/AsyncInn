using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class IAmenitiesMgmtServices : IAmenitiesMgmt
    {
        private HotelMgmtDBContext _context { get; }
        /// <summary>
        /// makes the connection with the DB
        /// </summary>
        /// <param name="context">the DB</param>
        public IAmenitiesMgmtServices(HotelMgmtDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// creates a row in the DB for a new amenity
        /// </summary>
        /// <param name="amenity">the amenity details</param>
        /// <returns>the amenities</returns>
        public async Task CreateAmenity(Amenities amenity)
        {
            _context.AmenitiesTable.Add(amenity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// gets the row from the amenity table with a specific id
        /// </summary>
        /// <param name="id">which amenity</param>
        /// <returns>the specific amenity</returns>
        public async Task<Amenities> GetAmenities(int id)
        {
            return await _context.AmenitiesTable.FirstOrDefaultAsync(amen => amen.ID == id);
        }

        /// <summary>
        /// gets all the amenities in the table
        /// </summary>
        /// <returns>all the amenities</returns>
        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.AmenitiesTable.ToListAsync();
        }

        /// <summary>
        /// queires the DB for all the amenities, and then filters it further based on the param
        /// </summary>
        /// <param name="id">keyword in the amenity name you would like to filter amenity list by</param>
        /// <returns>list of the amenities</returns>
        public async Task<IEnumerable<Amenities>> SearchAmenity(string id)
        {
            var amens = from a in _context.AmenitiesTable
                        select a;

            if (!String.IsNullOrEmpty(id))
            {
                amens = amens.Where(n => n.Name.Contains(id));
            }
            return await amens.ToListAsync();
        }

        /// <summary>
        /// updates the details of a given amenity
        /// </summary>
        /// <param name="amenity">which one</param>
        /// <returns>the amenties</returns>
        public async Task UpdateAmenity(Amenities amenity)
        {
            _context.AmenitiesTable.Update(amenity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// removes an amenity from the table
        /// </summary>
        /// <param name="id">which one</param>
        /// <returns>the remaining amenities</returns>
        public async Task<Amenities> DeleteAmenity(int id)
        {
            Amenities amenity = _context.AmenitiesTable.FirstOrDefault(amen => amen.ID == id);
            _context.AmenitiesTable.Remove(amenity);
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
