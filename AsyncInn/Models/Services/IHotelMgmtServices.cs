﻿using AsyncInn.Data;
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
        public IHotelMgmtServices(HotelMgmtDBContext context)
        {
            _context = context;
        }
        public async Task CreateHotel(Hotel hotel)
        {
            _context.HotelTable.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> DeleteHotel(int id)
        {
            Hotel hotel = _context.HotelTable.FirstOrDefault(hot => hot.ID == id);
            _context.HotelTable.Remove(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.HotelTable.FirstOrDefaultAsync(hot => hot.ID == id);
        }

        public async Task<IEnumerable<Hotel>> GetHotel()
        {
            return await _context.HotelTable.ToListAsync();
        }

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

        public async Task UpdateHotel(Hotel hotel)
        {
            _context.HotelTable.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
