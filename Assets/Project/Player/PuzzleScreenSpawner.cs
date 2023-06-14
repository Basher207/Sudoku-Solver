using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace SudokuGame
{
    public class PuzzleScreenSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject sudokuScreenPrefab;
        [Header("forward is used for trajectory")]
        [SerializeField] private Transform spawnPos;

        [SerializeField] private float launchSpeed;
        [SerializeField] private float rotationSpeed;

        private SudokuScreen InstantiateSudokuScreen()
        {
            Assert.IsNotNull(sudokuScreenPrefab, "SudokuScreen Prefab is not set");
            GameObject newSudokuScreen = Instantiate<GameObject>(sudokuScreenPrefab);

            newSudokuScreen.transform.position = spawnPos.position;
            newSudokuScreen.transform.rotation = spawnPos.rotation;

            SudokuScreen sudokuScreen = newSudokuScreen.GetComponent<SudokuScreen>();
            Assert.IsNotNull(sudokuScreen, "Prefab doesn't contain SudokuScreen script");

            return sudokuScreen;
        }

        /// <summary>
        /// Spawns a SudokuScreen and launches it from the player position
        /// </summary>
        public SudokuScreen SpawnSudokuScreen()
        {
            int[,] puzzle = SudokuGenerator.GeneratePuzzle();
            SudokuScreen sudokuScreen = InstantiateSudokuScreen();

            sudokuScreen.SetSudoku(puzzle);

            sudokuScreen.RigidBody.velocity = spawnPos.forward * launchSpeed;
            sudokuScreen.RigidBody.angularVelocity =
                Quaternion.AngleAxis(rotationSpeed, Random.insideUnitSphere).eulerAngles;

            //Turn the screen so its pointing away from its direction of travel
            sudokuScreen.transform.forward = -sudokuScreen.RigidBody.velocity;

            return sudokuScreen;
        }

        public void SpawnSudokuScreenFromClipBoard()
        {
            int[,] sudoku = SudokuGenerator.ImportSudokuFromClipboard();
            SudokuScreen sudokuScreen = SpawnSudokuScreen();
            sudokuScreen.SetSudoku(sudoku);
        }
    }
}