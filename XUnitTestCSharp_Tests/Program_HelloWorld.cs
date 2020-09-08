using System;
using Xunit;
using XUnitTestCSharp;
using NuGet.Frameworks;
using System.Collections.Generic;

namespace XUnitTestCSharp_Tests
{
    public class UnitTest1
    {
        // A "Fact" is a test of a method that should ALWAYS produce the same results (typically without parameters).
        [Fact]
        public void HelloWorld_Test()
        {
            Program.HelloWorld();
        }

        // A "Theory" is a test of a method when supplied with given values, and it should produce an expected result.
        // One test will run for each InlineData annotation (the test cases).
        [Theory,
        InlineData(1, 1, 2),
        InlineData(2, 2, 4),
        InlineData(5, 5, 10),
        InlineData(8, 4, 12)]
        public void Add_Test_Normal(int one, int two, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.Add(one, two));
        }

        [Theory,
        // We want to test all permutations of both arguments for the failure condition.
        InlineData(-1, 1),
        InlineData(1, -1),
        InlineData(-1, -1)]
        public void Add_Test_Negatives(int one, int two)
        {
            // Exception in this example can be replaced with a specific type of exception, and it will test for that and only that exception.
            Assert.Throws<Exception>(() => Program.Add(one, two));
        }

        [Theory,
        InlineData("Hello", "World"),
        InlineData("One", "Two")]
        public void Concatenate_Test_Normal(string one, string two)
        {
            // If a test method contains multiple assertions. The entire test will fail if any of them fail.
            Assert.Contains(one, Program.Concatentate(one, two));
            Assert.Contains(two, Program.Concatentate(one, two));

            // This kind of achieves the same thing but I wanted to demonstrate Contains.
            //Assert.Equal(one + two, Program.Concatentate(one, two));
        }

        [Theory,
        InlineData(5, 10)]
        public void AddToList_Test_Normal(int one, int two)
        {
            List<int> theList = new List<int>();
            Program.AddToList(one, two, theList);

            // Lists can't really be compared like the previous string example, so having multiple assertions here is required for this case.
            Assert.Contains(one, theList);
            Assert.Contains(two, theList);
        }


        [Theory,
        InlineData("one"),
        InlineData("yes")]
        public void IntParse_Test_Invalid(string test)
        {
            // Throws will require that a specific exception type is thrown, not any derived type, or any other type.
            Assert.Throws<FormatException>(() => int.Parse(test));

            // ThrowsAny will require that a specific exception or any derived exception is thrown.
            Assert.ThrowsAny<Exception>(() => int.Parse(test));
        }

    }
}
