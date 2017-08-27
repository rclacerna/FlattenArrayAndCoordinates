using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Customer.Tests
{
    [TestClass]
    public class InvitationTests
    {
        [TestMethod]
        public void TestInvitedCustomers_GivenNoDistanceLimit_DefaultsTo100Km()
        {
            var officeLocation = new Destination
            {
                Latitude = 53.339428,
                Longitude = -6.257664
            };

            var fileName = "customers.json";
            var expectedOutput = 16;

            var invite = new Invitation(officeLocation, fileName);

            var invitedList = invite.InvitedCustomers();

            invitedList.Count.ShouldBe(expectedOutput);
        }

        [TestMethod]
        public void TestInvitedCustomers_GivenValidInputs_ReturnsListValues()
        {
            var officeLocation = new Destination
            {
                Latitude = 53.339428,
                Longitude = -6.257664
            };

            var fileName = "customers.json";
            var expectedFirstListValue = "Christina McArdle";
            var expectedLastListValue = "Eoin Gallagher";

            var invite = new Invitation(officeLocation, fileName);
            var invitedList = invite.InvitedCustomers();

            invitedList[0].Name.ShouldBe(expectedFirstListValue);
            invitedList[15].Name.ShouldBe(expectedLastListValue);
        }

        [TestMethod]
        public void TestInvitedCustomers_Given300KmLimit_ReturnsListCount()
        {
            var officeLocation = new Destination
            {
                Latitude = 53.339428,
                Longitude = -6.257664
            };

            var fileName = "customers.json";
            var expectedOutput = 30;

            var invite = new Invitation(officeLocation, fileName, 300);

            var invitedList = invite.InvitedCustomers();

            invitedList.Count.ShouldBe(expectedOutput);
        }


        [TestMethod]
        public void TestSortInvitedCustomers_InvitedList_ReturnsSortedList()
        {
            var officeLocation = new Destination
            {
                Latitude = 53.339428,
                Longitude = -6.257664
            };

            var fileName = "customers.json";

            var invite = new Invitation(officeLocation, fileName);
            var invitedList = invite.InvitedCustomers();
            var sortedList = invite.SortInvitedCustomers(invitedList);

            // assert
            sortedList.First().User_Id.ShouldBeLessThan(sortedList.Last().User_Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "You're invited list cannot be empty :)")]

        public void TestSortInvitedCustomers_GivenNoList_Throws()
        {
            var officeLocation = new Destination
            {
                Latitude = 53.339428,
                Longitude = -6.257664
            };

            var fileName = "";

            var invite = new Invitation(officeLocation, fileName);
            var invitedList = new List<Customer>();
            invite.SortInvitedCustomers(invitedList);

            // assert from attribute
        }
    }
}
