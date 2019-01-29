using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please provide a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide an address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please provide a phone number")]
        public string PhoneNumber { get; set; }

        //navigation
        //public HotelRoom HotelRoom { get; set; }
        ICollection<HotelRoom> HRoom { get; set; }

    }
}
