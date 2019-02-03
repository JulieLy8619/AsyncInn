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
        [Required(ErrorMessage = "Please provide a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please pick a layout")]
        public LayoutEnum Layout { get; set; }

        //navigation
        //public HotelRoom HotelRoom { get; set; }
        //public RoomAmenities RoomAmenities { get; set; }
        public ICollection<HotelRoom> HRooms { get; set; }
        public ICollection<RoomAmenities> RAmenitites { get; set; }
    }
}
