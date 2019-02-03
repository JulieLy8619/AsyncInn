using System;
using Xunit;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AsyncInn_unittesting
{
    public class UnitTest1
    {
        //model amenities======================
        //get name
        [Fact]
        public void TestGetAmenitiesName()
        {
            Amenities testAmen1 = new Amenities();
            testAmen1.Name = "aName";
            Assert.Equal("aName", testAmen1.Name);
        }
        //set name
        [Fact]
        public void TestSetAmenitiesName()
        {
            Amenities testAmen2 = new Amenities();
            testAmen2.Name = "aName";
            testAmen2.Name = "newName";
            Assert.Equal("newName", testAmen2.Name);
        }
        //create
        [Fact]
        public async void TestCreateAmenities()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("CreateAmenities").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {

                Amenities amen1 = new Amenities();
                amen1.ID = 1;
                amen1.Name = "FoodCart";

                IAmenitiesMgmtServices amenService = new IAmenitiesMgmtServices(context);

                await amenService.CreateAmenity(amen1);

                var amen1Answer = context.AmenitiesTable.FirstOrDefault(a => a.ID == amen1.ID);

                Assert.Equal(amen1, amen1Answer);
            }
        }
        //read details
        [Fact]
        public async void TestReadAmenities()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("ReadAmenities").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {

                Amenities amen2 = new Amenities();
                amen2.ID = 1;
                amen2.Name = "tub";

                IAmenitiesMgmtServices amenService = new IAmenitiesMgmtServices(context);

                await amenService.CreateAmenity(amen2);
                var amen2Answer = await amenService.GetAmenities(1);

                Assert.Equal(amen2, amen2Answer);
            }
        }
        //edit
        [Fact]
        public async void TestEditAmenities()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("UpdateAmenities").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {

                Amenities amen3 = new Amenities();
                amen3.ID = 1;
                amen3.Name = "Bed";
                amen3.Name = "NewBed";

                IAmenitiesMgmtServices amenService = new IAmenitiesMgmtServices(context);

                await amenService.CreateAmenity(amen3);
                await amenService.UpdateAmenity(amen3);
                var amen3Answer = await amenService.GetAmenities(1);

                Assert.Equal("NewBed", amen3Answer.Name);
            }
        }

        //delete
        [Fact]
        public async void TestDeleteAmenities()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("DeleteAmenities").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {

                Amenities amen4 = new Amenities();
                amen4.ID = 1;
                amen4.Name = "Sink";

                IAmenitiesMgmtServices amenService = new IAmenitiesMgmtServices(context);

                await amenService.CreateAmenity(amen4);
                await amenService.DeleteAmenity(1);

                var amen4Answer = await amenService.GetAmenities(1);

                Assert.Null(amen4Answer);
            }
        }



        //model hotel==========================
        //get name
        [Fact]
        public void TestGetHotelName()
        {
            Hotel testHot1 = new Hotel();
            testHot1.Name = "hotName1";
            Assert.Equal("hotName1", testHot1.Name);
        }
        //set name
        [Fact]
        public void TestSetHotelName()
        {
            Hotel testHot2 = new Hotel();
            testHot2.Name = "hotName2";
            testHot2.Name = "newHotName";
            Assert.Equal("newHotName", testHot2.Name);
        }
        //get address
        [Fact]
        public void TestGetAddress()
        {
            Hotel testHot3 = new Hotel();
            testHot3.Address = "123 address";
            Assert.Equal("123 address", testHot3.Address);
        }
        //set address
        [Fact]
        public void TestSetAddress()
        {
            Hotel testHot4 = new Hotel();
            testHot4.Address = "123 test addy";
            testHot4.Address = "new addy 987";
            Assert.Equal("new addy 987", testHot4.Address);
        }
        //get phone number
        [Fact]
        public void TestGetPhone()
        {
            Hotel testHot5 = new Hotel();
            testHot5.PhoneNumber = "1234567890";
            Assert.Equal("1234567890", testHot5.PhoneNumber);
        }
        //set phone number
        [Fact]
        public void TestSetPhone()
        {
            Hotel testHot6 = new Hotel();
            testHot6.PhoneNumber = "9876543210";
            testHot6.PhoneNumber = "2069999999";
            Assert.Equal("2069999999", testHot6.PhoneNumber);
        }
        //create
        [Fact]
        public async void TestCreateHotel()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("CreateHotels").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {

                Hotel hot1 = new Hotel();
                hot1.ID = 1;
                hot1.Name = "TestHotelOne";
                hot1.Address = "FakeAddressOne";
                hot1.PhoneNumber = "FakePNumberOne";

                IHotelMgmtServices hotService = new IHotelMgmtServices(context);

                await hotService.CreateHotel(hot1);

                var hot1Answer = context.HotelTable.FirstOrDefault(h => h.ID == hot1.ID);

                Assert.Equal(hot1, hot1Answer);
            }
        }
        //read details
        [Fact]
        public async void TestReadHotel()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("ReadHotels").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {

                Hotel hot2 = new Hotel();
                hot2.ID = 1;
                hot2.Name = "TestHotelTwo";
                hot2.Address = "FakeAddressTwo";
                hot2.PhoneNumber = "FakePNumberTwo";

                IHotelMgmtServices hotService = new IHotelMgmtServices(context);

                await hotService.CreateHotel(hot2);
                var hot2Answer = await hotService.GetHotel(1);

                Assert.Equal(hot2, hot2Answer);
            }
        }
        //edit
        [Fact]
        public async void TestEditHotel()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("UpdateHotels").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {

                Hotel hot3 = new Hotel();
                hot3.ID = 1;
                hot3.Name = "TestHotel3";
                hot3.Address = "FakeAddress3";
                hot3.PhoneNumber = "FakePNumber3";
                hot3.PhoneNumber = "NewFakePNumber3";

                IHotelMgmtServices hotService = new IHotelMgmtServices(context);

                await hotService.CreateHotel(hot3);
                await hotService.UpdateHotel(hot3);
                var hot3Answer = await hotService.GetHotel(1);

                Assert.Equal("NewFakePNumber3", hot3Answer.PhoneNumber);
            }
        }

        //delete
        [Fact]
        public async void TestDeleteHotel()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("DeleteHotels").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {

                Hotel hot4 = new Hotel();
                hot4.ID = 1;
                hot4.Name = "TestHotel4";
                hot4.Address = "FakeAddress4";
                hot4.PhoneNumber = "FakePNumber4";

                IHotelMgmtServices hotService = new IHotelMgmtServices(context);

                await hotService.CreateHotel(hot4);
                await hotService.DeleteHotel(1);

                var hot4Answer = await hotService.GetHotel(1);

                Assert.Null(hot4Answer);
            }
        }



        //model room==============================
        //get name
        [Fact]
        public void TestGetRoomName()
        {
            Room testRm1 = new Room();
            testRm1.Name = "origName";
            Assert.Equal("origName", testRm1.Name);
        }
        //set name
        [Fact]
        public void TestSetRoomName()
        {
            Room testRm2 = new Room();
            testRm2.Name = "Bob";
            testRm2.Name = "Sally";
            Assert.Equal("Sally", testRm2.Name);
        }
        //get layout
        [Fact]
        public void TestGetLayout()
        {
            Room testRm3 = new Room();
            testRm3.Layout = LayoutEnum.OneBedroom;
            Assert.Equal(LayoutEnum.OneBedroom, testRm3.Layout);
        }
        //set layout
        [Fact]
        public void TestSetLayout()
        {
            Room testRm4 = new Room();
            testRm4.Layout = LayoutEnum.OneBedroom;
            testRm4.Layout = LayoutEnum.Studio;
            Assert.Equal(LayoutEnum.Studio, testRm4.Layout);
        }
        //create
        [Fact]
        public async void TestCreateRoom()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("CreateRooms").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {

                Room roo1 = new Room();
                roo1.ID = 1;
                roo1.Name = "CreativeRoomName";
                roo1.Layout = LayoutEnum.OneBedroom;

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);

                await rooService.CreateRoom(roo1);

                var roo1Answer = context.RoomTable.FirstOrDefault(r => r.ID == roo1.ID);

                Assert.Equal(roo1, roo1Answer);
            }
        }
        //read details
        [Fact]
        public async void TestReadRoom()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("ReadRooms").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {

                Room roo2 = new Room();
                roo2.ID = 1;
                roo2.Name = "A New Name";
                roo2.Layout = LayoutEnum.OneBedroom;

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);

                await rooService.CreateRoom(roo2);
                var roo2Answer = await rooService.GetRoom(1);

                Assert.Equal(roo2, roo2Answer);
            }
        }
        //edit
        [Fact]
        public async void TestEditRoom()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("UpdateRooms").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {

                Room roo3 = new Room();
                roo3.ID = 1;
                roo3.Name = "Edit room name";
                roo3.Layout = LayoutEnum.OneBedroom;
                roo3.Layout = LayoutEnum.Studio;

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);

                await rooService.CreateRoom(roo3);
                await rooService.UpdateRoom(roo3);

                var roo3Answer = await rooService.GetRoom(1);

                Assert.Equal(LayoutEnum.Studio, roo3Answer.Layout);
            }
        }
        //delete
        [Fact]
        public async void TestDeleteRoom()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("DeleteRooms").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {

                Room roo4 = new Room();
                roo4.ID = 1;
                roo4.Name = "Last Room Name";
                roo4.Layout = LayoutEnum.TwoBedroom;

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);

                await rooService.CreateRoom(roo4);
                await rooService.DeleteRoom(1);

                var roo4Answer = await rooService.GetRoom(1);

                Assert.Null(roo4Answer);
            }
        }

        //model hotelroom======================
        //get/set hotelID
        //get/set roomid
        //get/set roomnumber
        //get rate
        [Fact]
        public void TesGetRate()
        {
            HotelRoom hotRm1 = new HotelRoom();
            hotRm1.Rate = 10.00;
            Assert.Equal(10.00, hotRm1.Rate);
        }
        //set rate
        [Fact]
        public void TestSetRate()
        {
            HotelRoom hotRm2 = new HotelRoom();
            hotRm2.Rate = 10.00;
            hotRm2.Rate = 100.00;
            Assert.Equal(100.00, hotRm2.Rate);
        }
        //get petfriendly
        [Fact]
        public void TestGetPet()
        {
            HotelRoom hotRm3 = new HotelRoom();
            hotRm3.PetFriendly = true;
            Assert.True(hotRm3.PetFriendly);
        }
        //set petfriendly
        [Fact]
        public void TestSetPet()
        {
            HotelRoom hotRm4 = new HotelRoom();
            hotRm4.PetFriendly = true;
            hotRm4.PetFriendly = false;
            Assert.False(hotRm4.PetFriendly);
        }
        //create
        //read details
        //edit
        //delete


        //model room amenities===============
        //get/set amenitiesid
        //get/set roomid
        //create
        //read details
        //edit
        //delete

    }
}

//testing video is 1-30-9 about 30 mins in
//Getters/Setters on all Models
//Standard CRUD operations on all tables(test your services!)
//already Install-Package Microsoft.EntityFrameworkCore.InMemory

//[Fact]
//public void TestName()
//{
    
//}
