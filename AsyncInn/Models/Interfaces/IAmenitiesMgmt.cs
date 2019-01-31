using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenitiesMgmt
    {
        Task CreateAmenity(Amenities amenity);
        Task<Amenities> GetAmenities(int id);
        Task<IEnumerable<Amenities>> GetAmenities();
        Task<IEnumerable<Amenities>> SearchAmenity(string id);
        Task UpdateAmenity(Amenities amenity);
        Task<Amenities> DeleteAmenity(int id);
    }
}
