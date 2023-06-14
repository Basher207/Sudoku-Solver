using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SudokuGame
{
    public class SudokuScreenSolver : MonoBehaviour
    {

        [SerializeField] private SudokuGrid sudokuGrid;

        private bool startedSolving;

        public void StartSolve()
        {
            if (startedSolving)
                return;

            startedSolving = true;

            int[,] currentSudoku = sudokuGrid.currentSudoku;
            int[,] solvedSudoku = SudokuSolver.Solve(currentSudoku);

            sudokuGrid.UpdateNumbers(solvedSudoku);
        }
    }
}