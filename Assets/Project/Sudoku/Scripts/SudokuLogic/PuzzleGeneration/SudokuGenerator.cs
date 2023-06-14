using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SudokuGame
{
    public static class SudokuGenerator
    {

        /// <summary>
        /// Attempts to turn clipboard content into a sudoku
        /// </summary>
        /// <returns>Sudoku as int[,]</returns>
        public static int[,] ImportSudokuFromClipboard()
        {
            // Get the Sudoku from the clipboard
            string clipboardText = GUIUtility.systemCopyBuffer;
            return SudokuFromString(clipboardText);
        }
        
        /// <summary>
        /// Get Sudoku from a string
        /// </summary>
        /// <param name="sudokuString">Space separating columns, \n separating lines,</param>
        /// <returns>Sudoku as int[,]</returns>
        /// <exception cref="Exception">If wrong size of string is provided</exception>
        public static int[,] SudokuFromString (string sudokuString)
        {
        // Split the clipboard text into rows
            string[] rows = sudokuString.Split('\n');

            // Check if the input is valid
            if(rows.Length < SudokuConfig.SudokuSize)
            {
                throw new Exception("Invalid Sudoku size. The puzzle should be a " + SudokuConfig.SudokuSize + "x" + SudokuConfig.SudokuSize + " grid.");
            }

            int[,] sudoku = new int[SudokuConfig.SudokuSize, SudokuConfig.SudokuSize];

            for (int y = 0; y < SudokuConfig.SudokuSize; y++)
            {
                // Split the row into cells
                string[] cells = rows[y].Trim().Split(' ');

                if(cells.Length != SudokuConfig.SudokuSize)
                {
                    throw new Exception("Invalid Sudoku size. Each row should have " + SudokuConfig.SudokuSize + " numbers.");
                }

                for (int x = 0; x < SudokuConfig.SudokuSize; x++)
                {
                    // Parse each cell from string to int
                    if (int.TryParse(cells[x], out int cellValue))
                    {
                        sudoku[x, y] = cellValue;
                    }
                    else
                    {
                        throw new Exception("Invalid value '" + cells[x] + "' in Sudoku. All values should be integers between 0 and " + SudokuConfig.SudokuSize);
                    }
                }
            }

            return sudoku;
        }

        public static int[,] GeneratePuzzle(float normalisedFilledRate = 0.5f)
        {
            //Create an empty board, then fill it
            int[,] board = new int[SudokuConfig.SudokuSize, SudokuConfig.SudokuSize];

            if (!FillBoard(board))
                throw new Exception("Failed to generate a valid Sudoku puzzle.");

            // Remove some of the numbers to create a puzzle.
            for (int i = 0; i < SudokuConfig.SudokuSize; i++)
            for (int j = 0; j < SudokuConfig.SudokuSize; j++)
                if (Random.value < normalisedFilledRate) // probability of a cell to be hidden
                    board[i, j] = 0;

            return board;
        }


        // Recursive function, that uses backtracking to fill a board
        private static bool FillBoard(int[,] board)
        {
            int row, col;

            //If no location is unassigned, the board is full.
            if (!SudokuLogic.FindUnassignedLocation(board, out row, out col))
                return true; // success!



            //A list of the numbers that will be attempted, in a random order
            var numbers = Enumerable.Range(1, SudokuConfig.SudokuSize).OrderBy(x => Random.value).ToList();

            foreach (var number in numbers)
            {
                //If the number is placeable
                if (SudokuLogic.IsValid(board, row, col, number))
                {
                    board[row, col] = number; // Assign it to the board
                    if (FillBoard(board)) // Try to fill the rest of the board based on this number pick
                        return true;
                    board[row, col] = 0; // failure, reset number and continue
                }
            }

            return false; // backtrack back to the previous attempt. 
        }
    }
}