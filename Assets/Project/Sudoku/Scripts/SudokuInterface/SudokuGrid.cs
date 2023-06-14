using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace SudokuGame
{
    public class SudokuGrid : MonoBehaviour
    {
        [SerializeField] private RectTransform numbersParent;
        [SerializeField] private GameObject numberPrefab;

        [SerializeField]
        private SudokuNumber[] sudokuNumbers = new SudokuNumber[SudokuConfig.SudokuSize * SudokuConfig.SudokuSize];

        public int[,] currentSudoku { get; set; } = null;

        private SudokuNumber InstantiateNumber()
        {
            GameObject number = null;

#if UNITY_EDITOR
            number = PrefabUtility.InstantiatePrefab(numberPrefab, numbersParent) as GameObject;
#else
        number = Instantiate<GameObject>(numberPrefab, numbersParent);
#endif

            SudokuNumber sudokuNumber = number.GetComponent<SudokuNumber>();

            Assert.IsNotNull(sudokuNumber, "No SudokuNumber on numberPrefab");

            return sudokuNumber;
        }

        private int SudokuNumberIndex(int x, int y)
        {
            return x + y * SudokuConfig.SudokuSize;
        }

        public void UpdateNumbers(int[,] numbers)
        {
            currentSudoku = new int[SudokuConfig.SudokuSize, SudokuConfig.SudokuSize];
            
            for (int y = 0; y < SudokuConfig.SudokuSize; y++)
            {
                for (int x = 0; x < SudokuConfig.SudokuSize; x++)
                {
                    int sudokuNumberIndex = SudokuNumberIndex(x, y);
                    currentSudoku[x, y] = numbers[x, y];

                    int number = numbers[x, y];

                    string numberString = number == 0 ? " " : number.ToString();
                    sudokuNumbers[sudokuNumberIndex].SetNumber(numberString);
                }
            }
        }

        public void ReSpawnGrid()
        {
            numbersParent.DestroyChildrenImmediate();

            sudokuNumbers = new SudokuNumber[SudokuConfig.SudokuSize * SudokuConfig.SudokuSize];

            for (int y = 0; y < SudokuConfig.SudokuSize; y++)
            {
                for (int x = 0; x < SudokuConfig.SudokuSize; x++)
                {
                    Vector2 pos = new Vector2Int(x, -y);

                    SudokuNumber number = InstantiateNumber();
                    number.name += $" {x} - {y}";

                    //This assumes the numbers are anchored on the bottom left
                    //where 0, 0 is bottom left of the sudoku grid
                    Vector2 bottomLeftNormalisedPosition = pos / SudokuConfig.SudokuSize;
                    number.rectTransform.anchoredPosition = bottomLeftNormalisedPosition;

                    int sudokuIndex = SudokuNumberIndex(x, y);
                    sudokuNumbers[sudokuIndex] = number;
                }
            }
        }
    }
}