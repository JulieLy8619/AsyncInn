using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
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
            return await _context.AmenitiesTable.FirstOrDefault(amen => amen.ID == id);
        }

        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.AmenitiesTable.
        }

        public void UpdateAmenity(Amenities amenity)
        {

        }

        public void DeleteAmenity(int id)
        {
            Amenities amenity = _context.AmenitiesTable.FirstOrDefault(amen => amen.ID == id);
        }
    }
}
