using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using TMPro;
using UnityEngine.UI;

namespace SudokuGame
{
    public class SudokuScreen : MonoBehaviour
    {

        [SerializeField] private SudokuGrid sudokuGrid;
        [SerializeField] private Rigidbody rigidbody;

        
        [SerializeField] private TextMeshProUGUI timeForPuzzleGeneration;
        [SerializeField] private TextMeshProUGUI timeForPuzzleSolving;
        
        [SerializeField] private Image timeForPuzzleGenerationParent;
        [SerializeField] private Image timeForPuzzleSolvingParent;

        public Rigidbody RigidBody => rigidbody;
        public int[,] currentSudoku => sudokuGrid.currentSudoku;

        private bool puzzleSolved = false;

        private void Start()
        {
            Stopwatch stopwatch = new Stopwatch();

            if (currentSudoku == null)
            {
                stopwatch.Start();
                int[,] sudoku = SudokuGenerator.GeneratePuzzle();
                stopwatch.Stop();

                float ellapsedMilliseconds = (float)stopwatch.Elapsed.TotalMilliseconds;
                timeForPuzzleGeneration.text = $"{ellapsedMilliseconds.RoundDecimalPlace(5)}ms";
                
                timeForPuzzleGenerationParent.gameObject.SetActive(true);

                SetSudoku(sudoku);
            }
            else
            {
                timeForPuzzleGenerationParent.gameObject.SetActive(false);
            }

            puzzleSolved = false;
        }

        /// <summary>
        /// Set the Sudoku Grid
        /// </summary>
        /// <param name="sudoku"></param>
        public void SetSudoku(int[,] sudoku)
        {
            sudokuGrid.UpdateNumbers(sudoku);
        }


        /// <summary>
        /// Solve the currently loaded sudoku puzzle
        /// </summary>
        public void SolveSudoku()
        {
            if (puzzleSolved)
                return;

            puzzleSolved = true;

            int[,] currentSudoku = sudokuGrid.currentSudoku;

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            int[,] solvedSudoku = SudokuSolver.Solve(currentSudoku);
            stopwatch.Stop();

            float ellapsedMilliseconds = (float)stopwatch.Elapsed.TotalMilliseconds;
            timeForPuzzleSolving.text = $"{ellapsedMilliseconds.RoundDecimalPlace(5)}ms";

            sudokuGrid.UpdateNumbers(solvedSudoku);
        }
    }
}