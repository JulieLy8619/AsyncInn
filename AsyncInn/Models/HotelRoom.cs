using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int ID { get; set; }
        public int RoomNumber { get; set; }
        public double Rate { get; set; }
        public bool PetFriendly { get; set; }
    }
}
