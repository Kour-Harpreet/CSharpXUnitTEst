using System;
using System.Collections.Generic;

namespace XUnitTestCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {

            char playAgain = 'Y';
            bool validAgain = false;
            do
            {
                Console.Clear();
                PlayGame();
                do
                {
                    try
                    {
                        Console.Write("Would you like to play again? (Y/N): ");
                        playAgain = char.Parse(Console.ReadLine().ToUpper());
                        if (playAgain != 'N' && playAgain != 'Y')
                        {
                            throw new Exception("Must be 'Y' or 'N'.");
                        }
                        validAgain = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message} Please try again.");
                    }
                } while (!validAgain);
            } while (playAgain == 'Y');

            Console.WriteLine("Thank you for playing, please come again.");
        }

        public static void PlayGame()
        {
            // Purpose: Facilitate the playing of the game.
            // Input: None.
            // Output: None.
            char[,] board = new char[,] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            char gameBoardState, gameState = 'X';
            string gameOverMessage = "The game was a draw.";
            do
            {
                int playerMove = -1;
                bool validMove = false;
                PrintGameBoardNumbers();
                PrintGameBoard(board);
                do
                {
                    try
                    {
                        Console.Write($"Player {gameState}, please enter a square number to place your token in: ");
                        playerMove = int.Parse(Console.ReadLine());
                        if (playerMove < 1 || playerMove > 9)
                        {
                            throw new Exception("That square number does not exist.");
                        }
                        if (GetBoardToken(board, playerMove) != ' ')
                        {
                            throw new Exception("That square number is already occupied.");
                        }
                        validMove = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message} Please try again.");
                    }
                } while (!validMove);
                SetBoardToken(board, playerMove, gameState);
                gameBoardState = UpdateGameBoardState(board);
                gameState = gameState == 'X' ? 'O' : 'X';
                Console.Clear();
            } while (gameBoardState == 'N');

            if (gameBoardState == 'X')
            {
                gameOverMessage = "Player X was the winner!";
            }
            else if (gameBoardState == 'O')
            {
                gameOverMessage = "Player O was the winner!";
            }
            PrintGameBoard(board);
            Console.WriteLine(gameOverMessage);
        }
        public static void SetBoardToken(char[,] board, int squareNumber, char token)
        {
            // Purpose: Set the value for a given square number in the provided board.
            // Input: The current board (board), the square number to set (squareNumber), and the token to set it to (token).
            // Output: None (board affected by reference).
            switch (squareNumber)
            {
                case 1:
                    board[0, 0] = token;
                    break;
                case 2:
                    board[1, 0] = token;
                    break;
                case 3:
                    board[2, 0] = token;
                    break;
                case 4:
                    board[0, 1] = token;
                    break;
                case 5:
                    board[1, 1] = token;
                    break;
                case 6:
                    board[2, 1] = token;
                    break;
                case 7:
                    board[0, 2] = token;
                    break;
                case 8:
                    board[1, 2] = token;
                    break;
                case 9:
                    board[2, 2] = token;
                    break;
                default:
                    throw new Exception("That square number does not exist.");
            }
        }
        public static char GetBoardToken(char[,] board, int squareNumber)
        {
            // Purpose: Fetch the value for a given square number in the provided board.
            // Input: The current board (board), and the square number to fetch (squareNumber).
            // Output: The character in the indicated square number.
            char squareCharacter = ' ';
            switch (squareNumber)
            {
                case 1:
                    squareCharacter = board[0, 0];
                    break;
                case 2:
                    squareCharacter = board[1, 0];
                    break;
                case 3:
                    squareCharacter = board[2, 0];
                    break;
                case 4:
                    squareCharacter = board[0, 1];
                    break;
                case 5:
                    squareCharacter = board[1, 1];
                    break;
                case 6:
                    squareCharacter = board[2, 1];
                    break;
                case 7:
                    squareCharacter = board[0, 2];
                    break;
                case 8:
                    squareCharacter = board[1, 2];
                    break;
                case 9:
                    squareCharacter = board[2, 2];
                    break;
                default:
                    throw new Exception("That square number does not exist.");
            }
            return squareCharacter;
        }
        public static void PrintGameBoardNumbers()
        {
            // Purpose: Print the game board square numbers for a player to select.
            // Input: None.
            // Output: None.

            int number = 1;
            Console.Write("Game Board Positions:\n-------------\n");
            for (int r = 0; r <= 2; r++)
            {
                Console.Write("| ");
                for (int c = 0; c <= 2; c++)
                {
                    Console.Write(number + " | ");
                    number++;
                }
                Console.Write("\n-------------\n");
            }
        }
        public static void PrintGameBoard(char[,] board)
        {
            // Purpose: Print the game board based on the board array.
            // Input: The game board (board).
            // Output: None.

            Console.Write("Game Board Status:\n-------------\n");
            for (int r = 0; r <= 2; r++)
            {
                Console.Write("| ");
                for (int c = 0; c <= 2; c++)
                {
                    Console.Write(board[c, r] + " | ");
                }
                Console.Write("\n-------------\n");
            }
        }
        public static bool CheckFullBoard(char[,] board)
        {
            bool isFull = true;
            foreach (char square in board)
            {
                if (square == ' ')
                {
                    isFull = false;
                }
            }
            return isFull;
        }
        public static char UpdateGameBoardState(char[,] board)
        {
            // Purpose: Check if the game is over, and return a state that represents this.
            // Input: The game board (board).
            // Output: The game state.
            //      - 'N' = Not Over
            //      - 'D' = Draw
            //      - 'X' = X Wins
            //      - 'O' = O Wins
            char gameState = 'N';

            // Left Column (3 squares the same, and not empty)
            if (board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2] && board[0, 0] != ' ')
            {
                gameState = board[0, 0];
            }
            // Middle Column
            else if (board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2] && board[1, 0] != ' ')
            {
                gameState = board[1, 0];
            }
            // Right Column
            else if (board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2] && board[2, 0] != ' ')
            {
                gameState = board[2, 0];
            }
            // Top Row
            else if (board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0] && board[0, 0] != ' ')
            {
                gameState = board[0, 0];
            }
            // Middle Row
            else if (board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1] && board[0, 1] != ' ')
            {
                gameState = board[0, 0];
            }
            // Bottom Row
            else if (board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2] && board[0, 2] != ' ')
            {
                gameState = board[0, 0];
            }
            // NW-SE Diagonal
            else if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] != ' ')
            {
                gameState = board[0, 0];
            }
            // NE-SW Diagonal
            else if (board[2, 0] == board[1, 1] && board[2, 0] == board[0, 2] && board[2, 0] != ' ')
            {
                gameState = board[0, 0];
            }
            // Full Board
            else if (CheckFullBoard(board))
            {
                gameState = 'D';
            }

            return gameState;
        }


    }
}