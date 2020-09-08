using System;
using Xunit;
using XUnitTestCSharp;
using NuGet.Frameworks;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace XUnitTestCSharp_Tests
{
    public class Program_Test
    {
 
        [Fact]
        public void Program_PrintGameBoard_Normal()
        {
            char[,] array = new char[,] { { 'X', 'O', 'X' }, { 'X', 'O', 'X' }, { 'X', 'O', 'X' } };
            XUnitTestCSharp.Program.PrintGameBoard(array);
        }

        [Theory,
        InlineData(1, 'X', 0, 0),
        InlineData(2, 'X', 1, 0),
        InlineData(3, 'O', 2, 0),
        InlineData(4, 'O', 0, 1),
        InlineData(5, 'O', 1, 1),
        InlineData(6, 'O', 2, 1),
        InlineData(7, 'X', 0, 2),
        InlineData(8, 'X', 1, 2),
        InlineData(9, 'X', 2, 2)]
        public void Program_SetBoardToken_Normal(int squareNumber, char token, int arrayX, int arrayY)
        {
            char[,] array = new char[,] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            XUnitTestCSharp.Program.SetBoardToken(array, squareNumber, token);
            // First argument should be what's expected, and the second argument should be what we're checking.
            Assert.Equal(token, array[arrayX, arrayY]);
        }


        // We want to test our "Edge Cases", meaning cases that are right on the edge of failing/passing. This helps ensure that minor tweaks dont cause problems.
        // For example, if we were to change a condition from >= to >, and we were only testing values 5 greater than or less than our boundaries, we would not catch that error.
        [Theory,
        InlineData(0, 'X'),
        InlineData(-1, 'X'),
        InlineData(-100, 'O'),
        InlineData(10, 'O'),
        InlineData(100, 'O')]
        public void Program_SetBoardToken_OutOfBounds(int squareNumber, char token)
        {
            char[,] array = new char[,] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };

            Assert.Throws<Exception>(() => { XUnitTestCSharp.Program.SetBoardToken(array, squareNumber, token); });
        }

        [Theory,
        InlineData(1, 'X'),
        InlineData(2, 'X'),
        InlineData(3, 'O'),
        InlineData(4, 'O'),
        InlineData(5, 'O'),
        InlineData(6, 'O'),
        InlineData(7, 'X'),
        InlineData(8, 'X'),
        InlineData(9, 'X')]
        public void Program_GetBoardToken_Normal(int squareNumber, char token)
        {
            char[,] array = new char[,] { { 'X', 'O', 'X' }, { 'X', 'O', 'X' }, { 'O', 'O', 'X' } };
            // First argument should be what's expected, and the second argument should be what we're checking.
            Assert.Equal(token, XUnitTestCSharp.Program.GetBoardToken(array, squareNumber));
        }


        // We want to test our "Edge Cases", meaning cases that are right on the edge of failing/passing. This helps ensure that minor tweaks dont cause problems.
        // For example, if we were to change a condition from >= to >, and we were only testing values 5 greater than or less than our boundaries, we would not catch that error.
        [Theory,
        InlineData(0, 'X'),
        InlineData(-1, 'X'),
        InlineData(-100, 'O'),
        InlineData(10, 'O'),
        InlineData(100, 'O')]
        public void Program_GetBoardToken_OutOfBounds(int squareNumber, char token)
        {
            char[,] array = new char[,] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };

            Assert.Throws<Exception>(() => { XUnitTestCSharp.Program.GetBoardToken(array, squareNumber); });
        }
    }
}