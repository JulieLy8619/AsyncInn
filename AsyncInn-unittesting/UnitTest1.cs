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
        [Fact]
        public void TestGetHRHotelID()
        {
            HotelRoom hotRmA = new HotelRoom();
            hotRmA.HotelID = 1;
            Assert.Equal(1, hotRmA.HotelID);
        }
        [Fact]
        public void TestSetHRHotelID()
        {
            HotelRoom hotRmB = new HotelRoom();
            hotRmB.HotelID = 1;
            hotRmB.HotelID = 2;
            Assert.Equal(2, hotRmB.HotelID);
        }
        //get/set roomid
        [Fact]
        public void TestGetHRRoomID()
        {
            HotelRoom hotRmC = new HotelRoom();
            hotRmC.RoomID = 1;
            Assert.Equal(1, hotRmC.RoomID);
        }
        [Fact]
        public void TestSetHRRoomID()
        {
            HotelRoom hotRmD = new HotelRoom();
            hotRmD.RoomID = 1;
            hotRmD.RoomID = 2;
            Assert.Equal(2, hotRmD.RoomID);
        }
        //get/set roomnumber
        [Fact]
        public void TestGetRoomNumber()
        {
            HotelRoom hotRmE = new HotelRoom();
            hotRmE.RoomNumber = 123;
            Assert.Equal(123, hotRmE.RoomNumber);
        }
        [Fact]
        public void TestSetRoomNumber()
        {
            HotelRoom hotRmF = new HotelRoom();
            hotRmF.RoomNumber = 987;
            hotRmF.RoomNumber = 963;
            Assert.Equal(963, hotRmF.RoomNumber);
        }
        //get rate
        [Fact]
        public void TestGetRate()
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
        [Fact]
        public async void TestCreateHotelRoom()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("CreateHotelRooms").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {
                Hotel hot1 = new Hotel();
                hot1.ID = 1;
                hot1.Name = "TestHotelOne";
                hot1.Address = "FakeAddressOne";
                hot1.PhoneNumber = "FakePNumberOne";

                Room roo1 = new Room();
                roo1.ID = 1;
                roo1.Name = "CreativeRoomName";
                roo1.Layout = LayoutEnum.OneBedroom;

                HotelRoom hr1 = new HotelRoom();
                hr1.HotelID = 1;
                hr1.RoomNumber = 123;
                hr1.RoomID = 1;
                hr1.Rate = 10.00;
                hr1.PetFriendly = true;

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);
                IHotelMgmtServices hotService = new IHotelMgmtServices(context);

                await hotService.CreateHotel(hot1);
                await rooService.CreateRoom(roo1);

                context.HotelRoomTable.Add(hr1);
                await context.SaveChangesAsync();

                var hr1Answer = context.HotelRoomTable.FirstOrDefault(hr => hr.RoomNumber == hr1.RoomNumber);

                Assert.Equal(hr1, hr1Answer);
            }
        }
        //read details
        //I don't think I did this one right because it's like create
        [Fact]
        public async void TestReadHotelRoom()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("ReadHotelRooms").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {
                Hotel hot2 = new Hotel();
                hot2.ID = 1;
                hot2.Name = "TestHotel2";
                hot2.Address = "FakeAddress2";
                hot2.PhoneNumber = "FakePNumber2";

                Room roo2 = new Room();
                roo2.ID = 1;
                roo2.Name = "Room Name";
                roo2.Layout = LayoutEnum.OneBedroom;

                HotelRoom hr2 = new HotelRoom();
                hr2.HotelID = 1;
                hr2.RoomNumber = 456;
                hr2.RoomID = 1;
                hr2.Rate = 100.00;
                hr2.PetFriendly = false;

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);
                IHotelMgmtServices hotService = new IHotelMgmtServices(context);

                await hotService.CreateHotel(hot2);
                await rooService.CreateRoom(roo2);

                context.HotelRoomTable.Add(hr2);
                await context.SaveChangesAsync();

                var hr2Answer = context.HotelRoomTable.FirstOrDefault(hr => hr.RoomNumber == hr2.RoomNumber);

                Assert.Equal(hr2, hr2Answer);
            }
    }
        //edit
        [Fact]
        public async void TestUpdateHotelRoom()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("UpdateHotelRooms").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {
                Hotel hot3 = new Hotel();
                hot3.ID = 1;
                hot3.Name = "TestHotel3";
                hot3.Address = "FakeAddress3";
                hot3.PhoneNumber = "FakePNumber3";

                Room roo3 = new Room();
                roo3.ID = 1;
                roo3.Name = "HoneyMoon Suite";
                roo3.Layout = LayoutEnum.Studio;

                HotelRoom hr3 = new HotelRoom();
                hr3.HotelID = 1;
                hr3.RoomNumber = 789;
                hr3.RoomID = 1;
                hr3.Rate = 50.00;
                hr3.PetFriendly = false;
                hr3.PetFriendly = true;

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);
                IHotelMgmtServices hotService = new IHotelMgmtServices(context);

                await hotService.CreateHotel(hot3);
                await rooService.CreateRoom(roo3);

                context.HotelRoomTable.Add(hr3);
                await context.SaveChangesAsync();

                var hr3Answer = context.HotelRoomTable.FirstOrDefault(hr => hr.RoomNumber == hr3.RoomNumber);

                Assert.True(hr3Answer.PetFriendly);
            }
        }
        //delete hotel room
        [Fact]
        public async void TestDeleteHotelRoom()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("DeleteHotelRooms").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {
                Hotel hot4 = new Hotel();
                hot4.ID = 1;
                hot4.Name = "TestHotel4";
                hot4.Address = "FakeAddress4";
                hot4.PhoneNumber = "FakePNumber4";

                Room roo4 = new Room();
                roo4.ID = 1;
                roo4.Name = "Basement Suite";
                roo4.Layout = LayoutEnum.TwoBedroom;

                HotelRoom hr4 = new HotelRoom();
                hr4.HotelID = 1;
                hr4.RoomNumber = 963;
                hr4.RoomID = 1;
                hr4.Rate = 250.00;
                hr4.PetFriendly = true;

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);
                IHotelMgmtServices hotService = new IHotelMgmtServices(context);

                await hotService.CreateHotel(hot4);
                await rooService.CreateRoom(roo4);

                context.HotelRoomTable.Add(hr4);
                await context.SaveChangesAsync();

                //var deleteHR = await context.HotelRoomTable
                //.Include(h => h.Hotel)
                //.Include(h => h.Room)
                //.FirstOrDefaultAsync(m => m.HotelID == hr4.HotelID && m.RoomNumber == hr4.RoomNumber);
                context.HotelRoomTable.Remove(hr4);
                await context.SaveChangesAsync();

                var hr4Answer = context.HotelRoomTable.FirstOrDefault(hr => hr.RoomNumber == hr4.RoomNumber);

                Assert.Null(hr4Answer);
            }
        }

        //deletes hotel room if I delete hotel
        [Fact]
        public async void TestDeleteHotelRoom2()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("DeleteHotelRooms2").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {
                Hotel hot5 = new Hotel();
                hot5.ID = 1;
                hot5.Name = "TestHotel5";
                hot5.Address = "FakeAddress5";
                hot5.PhoneNumber = "FakePNumber5";

                Room roo5 = new Room();
                roo5.ID = 1;
                roo5.Name = "Tired room";
                roo5.Layout = LayoutEnum.TwoBedroom;

                HotelRoom hr5 = new HotelRoom();
                hr5.HotelID = 1;
                hr5.RoomNumber = 852;
                hr5.RoomID = 1;
                hr5.Rate = 90.00;
                hr5.PetFriendly = false;

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);
                IHotelMgmtServices hotService = new IHotelMgmtServices(context);

                await hotService.CreateHotel(hot5);
                await rooService.CreateRoom(roo5);

                context.HotelRoomTable.Add(hr5);
                await context.SaveChangesAsync();
                await hotService.DeleteHotel(1);

                var hr5Answer = context.HotelRoomTable.FirstOrDefault(hr => hr.RoomNumber == hr5.RoomNumber);

                Assert.Null(hr5Answer);
            }
        }

        //deletes hotel room if I delete room
        [Fact]
        public async void TestDeleteHotelRoom3()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("DeleteHotelRooms3").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {
                Hotel hot6 = new Hotel();
                hot6.ID = 1;
                hot6.Name = "TestHotel5";
                hot6.Address = "FakeAddress5";
                hot6.PhoneNumber = "FakePNumber5";

                Room roo6 = new Room();
                roo6.ID = 1;
                roo6.Name = "Tired room";
                roo6.Layout = LayoutEnum.TwoBedroom;

                HotelRoom hr6 = new HotelRoom();
                hr6.HotelID = 1;
                hr6.RoomNumber = 852;
                hr6.RoomID = 1;
                hr6.Rate = 90.00;
                hr6.PetFriendly = false;

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);
                IHotelMgmtServices hotService = new IHotelMgmtServices(context);

                await hotService.CreateHotel(hot6);
                await rooService.CreateRoom(roo6);

                context.HotelRoomTable.Add(hr6);
                await context.SaveChangesAsync();
                await rooService.DeleteRoom(1);

                var hr6Answer = context.HotelRoomTable.FirstOrDefault(hr => hr.RoomNumber == hr6.RoomNumber);

                Assert.Null(hr6Answer);
            }
        }

        //model room amenities===============
        //get/set amenitiesid
        [Fact]
        public void TestGetRMAmenID()
        {
            RoomAmenities roomAmenA = new RoomAmenities();
            roomAmenA.AmenitiesID = 1;
            Assert.Equal(1, roomAmenA.AmenitiesID);
        }
        [Fact]
        public void TestSetRMAmenID()
        {
            RoomAmenities roomAmenB = new RoomAmenities();
            roomAmenB.AmenitiesID = 1;
            roomAmenB.AmenitiesID = 2;
            Assert.Equal(2, roomAmenB.AmenitiesID);
        }
        //get/set roomid
        [Fact]
        public void TestGetRMRoomID()
        {
            RoomAmenities roomAmenC = new RoomAmenities();
            roomAmenC.AmenitiesID = 1;
            Assert.Equal(1, roomAmenC.AmenitiesID);
        }
        [Fact]
        public void TestSetRMRoomID()
        {
            RoomAmenities roomAmenD = new RoomAmenities();
            roomAmenD.AmenitiesID = 1;
            roomAmenD.AmenitiesID = 2;
            Assert.Equal(2, roomAmenD.AmenitiesID);
        }
        //create
        [Fact]
        public async void TestCreateRoomAmenity()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("CreateRoomAmenity").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {
                Room roo1 = new Room();
                roo1.ID = 1;
                roo1.Name = "CreativeRoomName";
                roo1.Layout = LayoutEnum.OneBedroom;

                Amenities ament1 = new Amenities();
                ament1.ID = 1;
                ament1.Name = "Just a name";

                RoomAmenities ra1 = new RoomAmenities();
                ra1.RoomID = 1;
                ra1.AmenitiesID = 1;
                

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);
                IAmenitiesMgmtServices amentService = new IAmenitiesMgmtServices(context);

                await amentService.CreateAmenity(ament1);
                await rooService.CreateRoom(roo1);

                context.RoomAmenitiesTable.Add(ra1);
                await context.SaveChangesAsync();

                var ra1Answer = context.RoomAmenitiesTable.FirstOrDefault(ra => ra.RoomID == ra1.RoomID && ra.AmenitiesID == ra1.AmenitiesID);

                Assert.Equal(ra1, ra1Answer);
            }
        }
        //read details
        //again I don't think this was right because it's like creat
        [Fact]
        public async void TestReadRoomAmenity()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("ReadRoomAmenity").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {
                Room roo2 = new Room();
                roo2.ID = 1;
                roo2.Name = "Some Name";
                roo2.Layout = LayoutEnum.OneBedroom;

                Amenities ament2 = new Amenities();
                ament2.ID = 1;
                ament2.Name = "Another Name";

                RoomAmenities ra2 = new RoomAmenities();
                ra2.RoomID = 1;
                ra2.AmenitiesID = 1;


                IRoomMgmtServices rooService = new IRoomMgmtServices(context);
                IAmenitiesMgmtServices amentService = new IAmenitiesMgmtServices(context);

                await rooService.CreateRoom(roo2);
                await amentService.CreateAmenity(ament2);

                context.RoomAmenitiesTable.Add(ra2);
                await context.SaveChangesAsync();

                var ra2Answer = context.RoomAmenitiesTable.FirstOrDefault(ra => ra.RoomID == ra2.RoomID && ra.AmenitiesID == ra2.AmenitiesID);

                Assert.Equal(ra2, ra2Answer);
            }
        }
        //edit
        [Fact]
        public async void TestEditRoomAmenity()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("UpdateRoomAmenity").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {
                Room roo3 = new Room();
                roo3.ID = 1;
                roo3.Name = "Some Name";
                roo3.Layout = LayoutEnum.OneBedroom;

                Amenities ament3 = new Amenities();
                ament3.ID = 1;
                ament3.Name = "Another Name";

                Amenities ament4 = new Amenities();
                ament4.ID = 2;
                ament4.Name = "NewName for Amenity";

                RoomAmenities ra3 = new RoomAmenities();
                ra3.RoomID = 1;
                ra3.AmenitiesID = 1;
                ra3.AmenitiesID = 2; //i don't think this was right for checking update


                IRoomMgmtServices rooService = new IRoomMgmtServices(context);
                IAmenitiesMgmtServices amentService = new IAmenitiesMgmtServices(context);

                await rooService.CreateRoom(roo3);
                await amentService.CreateAmenity(ament3);
                await amentService.CreateAmenity(ament4);

                context.RoomAmenitiesTable.Add(ra3);
                await context.SaveChangesAsync();

                var ra4Answer = context.RoomAmenitiesTable.FirstOrDefault(ra => ra.RoomID == ra3.RoomID && ra.AmenitiesID == ra3.AmenitiesID);

                Assert.Equal(2, ra4Answer.AmenitiesID);
            }
        }
        //delete
        [Fact]
        public async void TestDeleteRoomAmenity()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("DeleteRoomAmenity").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {
                Room roo4 = new Room();
                roo4.ID = 1;
                roo4.Name = "Balloon Room";
                roo4.Layout = LayoutEnum.OneBedroom;

                Amenities ament5 = new Amenities();
                ament5.ID = 1;
                ament5.Name = "bubbly";

                RoomAmenities ra3 = new RoomAmenities();
                ra3.RoomID = 1;
                ra3.AmenitiesID = 1;

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);
                IAmenitiesMgmtServices amentService = new IAmenitiesMgmtServices(context);

                await rooService.CreateRoom(roo4);
                await amentService.CreateAmenity(ament5);

                context.RoomAmenitiesTable.Add(ra3);
                await context.SaveChangesAsync();

                context.RoomAmenitiesTable.Remove(ra3);
                await context.SaveChangesAsync();

                var ra5Answer = context.RoomAmenitiesTable.FirstOrDefault(ra => ra.RoomID == ra3.RoomID && ra.AmenitiesID == ra3.AmenitiesID);

                Assert.Null(ra5Answer);
            }
        }

        //delete room amenity if I delete room
        [Fact]
        public async void TestDeleteRoomAmenity2()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("DeleteRoomAmenity2").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {
                Room roo5 = new Room();
                roo5.ID = 1;
                roo5.Name = "Flower Room";
                roo5.Layout = LayoutEnum.OneBedroom;

                Amenities ament6 = new Amenities();
                ament6.ID = 1;
                ament6.Name = "Pillow Fluff";

                RoomAmenities ra4 = new RoomAmenities();
                ra4.RoomID = 1;
                ra4.AmenitiesID = 1;

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);
                IAmenitiesMgmtServices amentService = new IAmenitiesMgmtServices(context);

                await rooService.CreateRoom(roo5);
                await amentService.CreateAmenity(ament6);

                context.RoomAmenitiesTable.Add(ra4);
                await context.SaveChangesAsync();
                await rooService.DeleteRoom(1);

                var ra6Answer = context.RoomAmenitiesTable.FirstOrDefault(ra => ra.RoomID == ra4.RoomID && ra.AmenitiesID == ra4.AmenitiesID);

                Assert.Null(ra6Answer);
            }
        }

        //delete room amenity if I delete amenity
        [Fact]
        public async void TestDeleteRoomAmenity3()
        {
            DbContextOptions<HotelMgmtDBContext> options = new DbContextOptionsBuilder<HotelMgmtDBContext>().UseInMemoryDatabase("DeleteRoomAmenity3").Options;

            using (HotelMgmtDBContext context = new HotelMgmtDBContext(options))
            {
                Room roo6 = new Room();
                roo6.ID = 1;
                roo6.Name = "Balloon Room";
                roo6.Layout = LayoutEnum.OneBedroom;

                Amenities ament7 = new Amenities();
                ament7.ID = 1;
                ament7.Name = "bubbly";

                RoomAmenities ra5 = new RoomAmenities();
                ra5.RoomID = 1;
                ra5.AmenitiesID = 1;

                IRoomMgmtServices rooService = new IRoomMgmtServices(context);
                IAmenitiesMgmtServices amentService = new IAmenitiesMgmtServices(context);

                await rooService.CreateRoom(roo6);
                await amentService.CreateAmenity(ament7);

                context.RoomAmenitiesTable.Add(ra5);
                await context.SaveChangesAsync();
                await amentService.DeleteAmenity(1);

                var ra7Answer = context.RoomAmenitiesTable.FirstOrDefault(ra => ra.RoomID == ra5.RoomID && ra.AmenitiesID == ra5.AmenitiesID);

                Assert.Null(ra7Answer);
            }
        }
    }
}


