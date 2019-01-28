using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Amenities
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        
        //navigation
        //public RoomAmenities RoomAmentities { get; set; }
        ICollection<RoomAmenities> Rooms { get; set; }
    }
}
