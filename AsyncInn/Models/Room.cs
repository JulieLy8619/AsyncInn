using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public enum LayoutEnum
    {
        Studio = 0,
        [Display(Name="1 Bedroom")]
        OneBedroom = 1,
        [Display(Name = "2 Bedrooms")]
        TwoBedroom = 2
    }
    public class Room
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public LayoutEnum Layout { get; set; }

        //navigation
        //public HotelRoom HotelRoom { get; set; }
        //public RoomAmenities RoomAmenities { get; set; }
        ICollection<HotelRoom> HRooms { get; set; }
        ICollection<RoomAmenities> Amenitites { get; set; }
    }
}
