using System;
using Xunit;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore.Design;


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
        //read details
        //edit
        //delete



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
        //read details
        //edit
        //delete


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
        //read details
        //edit
        //delete


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
