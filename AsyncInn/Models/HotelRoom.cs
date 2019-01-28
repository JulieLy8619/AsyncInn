using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        public int RoomID { get; set; }
        public double Rate { get; set; }
        public bool PetFriendly { get; set; }

        //navigation
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
