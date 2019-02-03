using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class IHotelMgmtServices : IHotelMgmt
    {
        private HotelMgmtDBContext _context { get; }
        /// <summary>
        /// makes the connection with the DB
        /// </summary>
        /// <param name="context">the DB</param>
        public IHotelMgmtServices(HotelMgmtDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// adds a hotel row to the table
        /// </summary>
        /// <param name="hotel">the hotel information</param>
        /// <returns>the hotels</returns>
        public async Task CreateHotel(Hotel hotel)
        {
            _context.HotelTable.Add(hotel);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// removes a hotel row from the table
        /// </summary>
        /// <param name="id">which hotel</param>
        /// <returns>the hotels</returns>
        public async Task<Hotel> DeleteHotel(int id)
        {
            Hotel hotel = _context.HotelTable.FirstOrDefault(hot => hot.ID == id);
            _context.HotelTable.Remove(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        /// <summary>
        /// gets the row from the hotel table with a specific id
        /// </summary>
        /// <param name="id">which hotel</param>
        /// <returns>the hotel details</returns>
        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.HotelTable.FirstOrDefaultAsync(hot => hot.ID == id);
        }

        /// <summary>
        /// gets all the rows from the hotel table
        /// </summary>
        /// <returns>all the hotels</returns>
        public async Task<IEnumerable<Hotel>> GetHotel()
        {
            return await _context.HotelTable.ToListAsync();
        }

        /// <summary>
        /// queires the DB for all the hotels, and then filters it further based on the param
        /// </summary>
        /// <param name="id">keyword in the hotel name you would like to filter hotel list by</param>
        /// <returns>list of the hotels</returns>
        public async Task<IEnumerable<Hotel>> SearchHotel(string id)
        {

            var hots = from h in _context.HotelTable
                       select h;
            //jimmy hint: i will need to loop through the different hotels and linq their rooms
            foreach (Hotel hot in hots)
            {
                var hRms = from hr in _context.HotelRoomTable
                           where hr.HotelID == hot.ID
                           select hr;
                hot.HRoom = await hRms.ToListAsync();
            }

            if (!String.IsNullOrEmpty(id))
            {
                hots = hots.Where(n => n.Name.Contains(id));
            }
            return await hots.ToListAsync();
        }

        /// <summary>
        /// updates the hotels details in the DB
        /// </summary>
        /// <param name="hotel">which hotel</param>
        /// <returns>the hotels</returns>
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.HotelTable.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
