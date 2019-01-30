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
        public IAmenitiesMgmtServices(HotelMgmtDBContext context)
        {
            _context = context;
        }

        public async Task CreateAmenity(Amenities amenity)
        {
            _context.AmenitiesTable.Add(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task<Amenities> GetAmenities(int id)
        {
            return await _context.AmenitiesTable.FirstOrDefaultAsync(amen => amen.ID == id);
        }

        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.AmenitiesTable.ToListAsync();
        }

        public async Task UpdateAmenity(Amenities amenity)
        {
            _context.AmenitiesTable.Update(amenity);
            await _context.SaveChangesAsync();
        }
        //public async void UpdateAmenity(Amenities amenity)
        //{
        //    _context.AmenitiesTable.Update(amenity);
        //    await _context.SaveChangesAsync();
        //}

        public async Task<Amenities> DeleteAmenity(int id)
        {
            Amenities amenity = _context.AmenitiesTable.FirstOrDefault(amen => amen.ID == id);
            _context.AmenitiesTable.Remove(amenity);
            await _context.SaveChangesAsync();
            return amenity;
        }
        //public bool ExistAmenity(int id)
        //{
        //    var findAmend = await _context.AmenitiesTable.FindAsync(id);
        //    _context.AmenitiesTable.Remove(findAmend);
        //    await _context.SaveChangesAsync();
            
        //    return _context.AmenitiesTable.Any(e => e.ID == id);
        //}
    }
}
