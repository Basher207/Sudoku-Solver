using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

namespace SudokuGame
{
    public class SudokuRandomScreenSpawner : MonoBehaviour
    {

        [SerializeField] private GameObject sudokuScreenPrefab;
        [SerializeField] private int numberOfScreensToSpawn;


        private void Start()
        {
            for (int i = 0; i < numberOfScreensToSpawn; i++)
            {
                InstantiateSudokuScreen();
            }
        }

        private void InstantiateSudokuScreen()
        {
            Assert.IsNotNull(sudokuScreenPrefab, "SudokuScreen Prefab is not set");
            GameObject newSudokuScreen = Instantiate<GameObject>(sudokuScreenPrefab);

            newSudokuScreen.transform.position = transform.TransformPoint(Random.insideUnitSphere);
            newSudokuScreen.transform.rotation = Random.rotation;
        }

        private void OnDrawGizmosSelected()
        {
            Matrix4x4 oldMatrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;

            Gizmos.DrawWireSphere(Vector3.zero, 1f);

            Gizmos.matrix = oldMatrix;
        }
    }
}