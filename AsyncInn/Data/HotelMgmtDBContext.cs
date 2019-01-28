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
            modelBuilder.Entity<RoomAmenities>().HasKey(ra => new { ra.AmenitiesID, ra.RoomID });
            modelBuilder.Entity<HotelRoom>().HasKey(hr => new { hr.HotelID, hr.RoomNumber });
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Balcony"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "In room kitchen"
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Mini bar"
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Jet tub"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "High speed internet"
                },
                new Hotel
                {
                    ID = 1,
                    Name = "J&J Hotel",
                    Address = "123 Fake Street Seattle, WA 98121",
                    PhoneNumber = "206 123 4567"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "JK Hotel",
                    Address = "456 Fake Street Seattle, WA 98155",
                    PhoneNumber = "206 987 6543"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Seattle Hide Away Hotel",
                    Address = "789 Fake Street Seattle, WA 98040",
                    PhoneNumber = "425 999 9999"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Up & Up Hotel",
                    Address = "123 Fake Lane Seattle, WA 98121",
                    PhoneNumber = "206 112 2334"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "No Wheres Land Hotel",
                    Address = "456 Fake Place Seattle, WA 98133",
                    PhoneNumber = "206 998 7655"
                },
                new Room
                {
                    ID = 1,
                    Name = "Sleepless in Seattle",
                    Layout = LayoutEnum.Studio
                },
                new Room
                {
                    ID = 2,
                    Name = "Stay in Bed",
                    Layout = LayoutEnum.TwoBedroom
                },
                new Room
                {
                    ID = 3,
                    Name = "Gogo",
                    Layout = LayoutEnum.OneBedroom
                },
                new Room
                {
                    ID = 4,
                    Name = "HoneyMoon",
                    Layout = LayoutEnum.TwoBedroom
                },
                new Room
                {
                    ID = 5,
                    Name = "Red Solo Cup",
                    Layout = LayoutEnum.TwoBedroom
                },
                new Room
                {
                    ID = 6,
                    Name = "Blue Solo Hen",
                    Layout = LayoutEnum.Studio
                }
                );
        }

        //sets up our tables
        public DbSet<Amenities> AmenitiesTable {get;set;}
        public DbSet<Hotel> HotelTable { get; set; }
        public DbSet<HotelRoom> HotelRoomTable { get; set; }
        public DbSet<Room> RoomTable { get; set; }
        public DbSet<RoomAmenities> RoomAmenitiesTable { get; set; }
    }
}
