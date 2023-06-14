using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SudokuGame
{
    public static class SudokuLogic
    {
        /// <summary>
        /// Returns coords of an unassigned location if one exists
        /// </summary>
        /// <returns>true if an unassigned location is found</returns>
        public static bool FindUnassignedLocation(int[,] grid, out int row, out int col)
        {
            for (row = 0; row < SudokuConfig.SudokuSize; row++)
            for (col = 0; col < SudokuConfig.SudokuSize; col++)
                if (grid[row, col] == 0)
                    return true;
            col = -1;
            row = -1;
            return false;
        }

        /// <summary>
        /// Does the number exist in row
        /// </summary>
        public static bool UsedInRow(int[,] grid, int row, int number)
        {
            for (var col = 0; col < SudokuConfig.SudokuSize; col++)
                if (grid[row, col] == number)
                    return true;
            return false;
        }

        /// <summary>
        /// Does the number exist in column
        /// </summary>
        public static bool UsedInCol(int[,] grid, int col, int number)
        {
            for (var row = 0; row < SudokuConfig.SudokuSize; row++)
                if (grid[row, col] == number)
                    return true;
            return false;
        }

        /// <summary>
        /// Does the number exist in a box
        /// </summary>
        public static bool UsedInBox(int[,] grid, int boxStartRow, int boxStartCol, int number)
        {
            for (int row = 0; row < SudokuConfig.SudokuBoxSize; row++)
                for (int col = 0; col < SudokuConfig.SudokuBoxSize; col++)
                    if (grid[row + boxStartRow, col + boxStartCol] == number)
                        return true;
            return false;
        }

        /// <summary>
        /// Returns whether a number would be legal to place in a certain coordinate
        /// </summary>
        public static bool IsValid(int[,] grid, int row, int col, int number)
        {
            return !UsedInRow(grid, row, number) &&
                   !UsedInCol(grid, col, number) &&
                   !UsedInBox(grid, row - row % 3, col - col % 3, number);
        }

        /// <summary>
        /// prints out a sudoku puzzle in the space/newline format
        /// </summary>
        public static void ConsolePrintPuzzle(int[,] puzzle)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < SudokuConfig.SudokuSize; i++)
            {
                for (int j = 0; j < SudokuConfig.SudokuSize; j++)
                    output.Append($"{puzzle[i, j]} ");
                output.Append($"\n");
            }

            Debug.Log(output);
        }
    }
}