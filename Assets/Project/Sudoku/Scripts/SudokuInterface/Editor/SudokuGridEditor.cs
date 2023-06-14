using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SudokuGame
{
    [CustomEditor(typeof(SudokuGrid))]
    public class SudokuGridEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            SudokuGrid sudokuGrid = (SudokuGrid)target;
            if (GUILayout.Button("Update Grid"))
            {
                sudokuGrid.ReSpawnGrid();
            }

            EditorUtility.SetDirty(sudokuGrid);
        }
    }
}