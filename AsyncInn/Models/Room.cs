using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public enum LayoutEnum
    {
        Studio = 0,
        OneBedroom = 1,
        TwoBedroom = 2
    }
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public LayoutEnum Layout { get; set; }

        //navigation
        //public HotelRoom HotelRoom { get; set; }
        //public RoomAmenities RoomAmenities { get; set; }
        ICollection<HotelRoom> HRooms { get; set; }
        ICollection<RoomAmenities> Amenitites { get; set; }
    }
}
