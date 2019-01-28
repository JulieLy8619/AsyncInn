using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class HotelMgmtDBContext : DbContext
    {
        public HotelMgmtDBContext(DbContextOptions<HotelMgmtDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adds our composit keys
        }

        //sets up our tables
        public DbSet<Amenities> AmenitiesTable {get;set;}
        public DbSet<Hotel> HotelTable { get; set; }
        public DbSet<HotelRoom> HotelRoomTable { get; set; }
        public DbSet<Room> RoomTable { get; set; }
        public DbSet<RoomAmenities> RoomAmenitiesTable { get; set; }
    }
}
