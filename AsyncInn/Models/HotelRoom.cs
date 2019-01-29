using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        [Display(Name="Hotel Name")]
        public int HotelID { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        [Display(Name = "Room Name")]
        public int RoomID { get; set; }
        [DataType(DataType.Currency)]
        public double Rate { get; set; }
        [Display(Name = "Pet Friendly")]
        public bool PetFriendly { get; set; }

        //navigation
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
