using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;


namespace Flatten.Tests
{
    [TestClass]
    public class FlattenArrayTest
    {

        [TestMethod]
        public void TestFlattenFunction_GivenOneNestedList_ReturnsFlatList()
        {
            var inputArrayList = new List<object> { 1, new List<object> { 2, 3 } };

            var expectedOutput = new List<object> { 1, 2, 3 };

            var testOutput = FlattenArray.Flatten(inputArrayList);

            testOutput.ShouldBe(expectedOutput);
        }

        //2d array
        [TestMethod]
        public void TestFlattenFunction_GivenMultipleNestedList_ReturnsFlatList()
        {
            var inputArrayList = new List<object>{ 1,new List<object> {2 }, new List<object>  { new List<object>
                { 3, 4  }, 5  },  new List<object> { new List<object>
                {new List<object>() } },new List<object> { new List<object>
                {new List<object> {6} } },   7,  8, new List<object>()};

            var expectedOutput = new List<object> { 1, 2, 3, 4, 5, 6, 7, 8 };

            var testOutput = FlattenArray.Flatten(inputArrayList);

            testOutput.ShouldBe(expectedOutput);
        }

        [TestMethod]
        public void TestFlattenFunction_GivenEmptyList_ReturnsEmptyList()
        {
            var inputArrayList = new List<object> { };

            var expectedOutput = new List<object> { };

            var testOutput = FlattenArray.Flatten(inputArrayList);

            testOutput.ShouldBe(expectedOutput);
        }

        [TestMethod]
        public void TestFlattenFunction_GivenListWithStrings_ReturnsFlatIntList()
        {
            var inputArrayList = new List<object>
            {
                "A",
                new List<object> {1},
                new List<object>
                {
                    new List<object>
                        {"B", 2},
                    3
                }
            };

            var expectedOutput = new List<object> { "A", 1, "B", 2, 3 };

            var testOutput = FlattenArray.Flatten(inputArrayList);

            testOutput.ShouldBe(expectedOutput);
        }
    }
}
