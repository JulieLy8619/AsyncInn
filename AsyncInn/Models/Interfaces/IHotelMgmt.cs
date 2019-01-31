using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelMgmt
    {
        Task CreateHotel(Hotel hotel);
        Task<Hotel> GetHotel(int id);
        Task<IEnumerable<Hotel>> GetHotel();
        Task<IEnumerable<Hotel>> SearchHotel(string id);
        Task UpdateHotel(Hotel hotel);
        Task<Hotel> DeleteHotel(int id);
    }
}
