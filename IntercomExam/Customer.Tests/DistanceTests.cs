using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Customer.Tests
{
    [TestClass]
    public class DistanceTests
    {
        [TestMethod]
        public void TestConvertDegToRadians_GivenADouble_Convert()
        {
            var input = 53.339428;
            var expectedOutput = 0.93094864;
            var distance = new Distance();

            var testOutput = distance.ConvertDegToRadians(input);
            var roundedOutput = Math.Round(testOutput, 8);

            //assert
            roundedOutput.ShouldBe(Math.Round(expectedOutput, 8));
        }

        [TestMethod]
        public void TestCalculateDistance_GivenValidCoord_Calculate()
        {
            var customer = new Customer();
            var destination = new Destination();
            var distance = new Distance();
            var expectedOutput = 42;

            customer.Latitude = 52.986375;
            customer.Longitude = -6.043701;
            destination.Latitude = 53.339428;
            destination.Longitude = -6.257664;

            var testOutput = distance.CalculateDistance(destination, customer);

            //assert
            testOutput.ShouldBe(expectedOutput);
        }

        [TestMethod]
        public void TestCalculateDistance_GivenHawaiiCoord_Calculate()
        {
            var honoluluCity = new Customer();
            var intercomDublin = new Destination();
            var distance = new Distance();
            var expectedOutput = 11275;

            honoluluCity.Latitude = 21.315603;
            honoluluCity.Longitude = -157.858093;
            intercomDublin.Latitude = 53.339428;
            intercomDublin.Longitude = -6.257664;

            var testOutput = distance.CalculateDistance(intercomDublin, honoluluCity);

            //assert
            testOutput.ShouldBe(expectedOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Please enter valid coordinates")]
        public void TestCalculateDistance_GivenZeroValues_throw()
        {
            var customer = new Customer();
            var destination = new Destination();
            var distance = new Distance();

            customer.Latitude = 0;
            customer.Longitude = -6.043701;
            destination.Latitude = 0;
            destination.Longitude = -0;

            distance.CalculateDistance(destination, customer);

            //assert from attribute
        }


        [TestMethod]
        [ExpectedException(typeof(Exception), "Please enter valid coordinates")]
        public void TestCalculateDistance_GivenNoValue_throw()
        {
            var customer = new Customer();
            var destination = new Destination();
            var distance = new Distance();

            distance.CalculateDistance(destination, customer);

            //assert from attribute
        }
    }
}