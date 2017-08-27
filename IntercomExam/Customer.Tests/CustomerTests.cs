using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Customer.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void TestGetCustomerList_WhenfileExists_CountShouldBeSame()
        {
            var inputFileName = "customers.json";
            var customer = new Customer();

            var expectedOutput = customer.GetCustomerList(inputFileName);

            // assert
            expectedOutput.Count.ShouldBe(32);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGetCustomerList_WhenNameDoesNotExists_Throw()
        {
            var inputFileName = "notExists.json";
            var customer = new Customer();

            customer.GetCustomerList(inputFileName);

            //assert from attribute
        }

        [TestMethod]
        public void TestGetCustomerList_WhenFileExists_ReturnFirstNameInList()
        {
            var inputFileName = "customers.json";
            var expectedOutput = "Christina McArdle";
            var customer = new Customer();

            var customerList = customer.GetCustomerList(inputFileName);
            var testOutput = customerList[0].Name;

            // assert
            testOutput.ShouldBe(expectedOutput);
        }
    }
}
