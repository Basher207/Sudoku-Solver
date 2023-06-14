using System;

namespace SudokuGame
{
    public static class SudokuSolver
    {
        /// <summary>
        /// Returns a solved copy of a Sudoku, if one exists
        /// </summary>
        /// <returns>new filled out sudoku board array</returns>
        /// <exception cref="Exception">If no valid solution is found </exception>
        public static int[,] Solve(int[,] board)
        {
            var copy = (int[,])board.Clone();
            if (SolveBoard(copy))
                return copy;
            else
                throw new Exception("This puzzle cannot be solved.");
        }

        /// <summary>
        /// Finds the solution to a sudoku board, using recursion and backtracking. 
        /// </summary>
        private static bool SolveBoard(int[,] board)
        {
            for (int row = 0; row < SudokuConfig.SudokuSize; row++)
            {
                for (int col = 0; col < SudokuConfig.SudokuSize; col++)
                {
                    //not 0 means this box is already assigned
                    if (board[row, col] != 0)
                    {
                        continue;
                    }
                    
                    //Try every possible number
                    for (int num = 1; num <= SudokuConfig.SudokuSize; num++)
                    {
                        if (SudokuLogic.IsValid(board, row, col, num))
                        {
                            board[row, col] = num;
                            //Recursively call the SolveBoard function
                            //If the recursion fails, undo the assignment.
                            //Then try next number
                            if (SolveBoard(board))
                            {
                                return true;
                            }
                            else
                            {
                                board[row, col] = 0; // undo assignment
                            }
                        }
                    }

                    return false; // trigger backtracking
                }
            }

            return true; // puzzle solved
        }
    }
}