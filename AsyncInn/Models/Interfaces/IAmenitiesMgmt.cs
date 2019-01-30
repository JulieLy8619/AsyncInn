using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IAmenitiesMgmt
    {
        Task CreateAmenity(Amenities amenity);
        Task<Amenities> GetAmenities(int id);
        Task<IEnumerable<Amenities>> GetAmenities();
        void UpdateAmenity(Amenities amenity);
        void DeleteAmenity(int id);
    }
}
