using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

namespace SudokuGame
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float speed = 3.0f;


        /// <summary>
        /// Request movement from the player
        /// </summary>
        /// <param name="movementInput">movement in local space (z is forward/back, x is left/right) </param>
        public void UpdateMovement(Vector3 movementInput)
        {
            Vector3 forwardMovement = transform.forward * movementInput.z;
            Vector3 rightMovement = transform.right * movementInput.x;

            characterController.SimpleMove(speed * (forwardMovement + rightMovement));
        }
    }
}