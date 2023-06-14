using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace SudokuGame
{
    public class UserinputController : MonoBehaviour
    {

        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PuzzleScreenSpawner puzzleScreenSpawner;
        [SerializeField] private PlayerObjectGrabber playerObjectGrabber;

        [SerializeField] private KeyCode dropGrabbedObject;
        [SerializeField] private KeyCode spawnNewSudoku;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(spawnNewSudoku))
            {
                puzzleScreenSpawner.SpawnSudokuScreen();
            }

            if (Input.GetKeyDown(dropGrabbedObject))
            {
                playerObjectGrabber.ReleaseSelectedObject();
            }

            playerMovement.UpdateMovement(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));
        }
    }
}