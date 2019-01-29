using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        [Display(Name = "Amenity Name")]
        public int AmenitiesID { get; set; }
        [Display(Name = "Room Name")]
        public int RoomID { get; set; }

        //navigations
        public Amenities Amenities { get; set; }
        public Room Room { get; set; }
        //ICollection<Room> Rooms { get; set; }
        //ICollection<Amenities> Amenitites { get; set; }
    }
}
