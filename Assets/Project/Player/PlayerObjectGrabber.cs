using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SudokuGame
{
    public class PlayerObjectGrabber : MonoBehaviour
    {
        [SerializeField] private Transform objectHolder;
        [SerializeField] private float moveSpeed;

        private GrabbableObject currentlyHeldObject;
        
        public GrabbableObject CurrentlyHeldObject => currentlyHeldObject;

        private void Start()
        {
            GrabbableObject.OnGrabbableObjectClicked += GrabObject;
            GrabbableObject.OnGrabbableObjectReleaseRequested += RequestObjectRelease;
        }
        
        private void Update()
        {
            UpdateSelectedObjectMoveToHoldPosition();
        }

        /// <summary>
        /// Release object, if its the held object
        /// </summary>
        /// <param name="grabbableObject"></param>
        public void RequestObjectRelease(GrabbableObject grabbableObject)
        {
            if (grabbableObject == currentlyHeldObject)
            {
                ReleaseSelectedObject();
            }
        }


        private void GrabObject(GrabbableObject grabbableObject)
        {
            ReleaseSelectedObject();
            
            if (grabbableObject.GrabObject())
                currentlyHeldObject = grabbableObject;
        }
        
        public void ReleaseSelectedObject()
        {
            if (currentlyHeldObject == null)
                return;
            currentlyHeldObject.ReleaseObject();
            currentlyHeldObject = null;
        }

        public void UpdateSelectedObjectMoveToHoldPosition()
        {
            if (currentlyHeldObject)
            {
                Vector3 holdPosition = objectHolder.position;
                Quaternion holdRotation = objectHolder.rotation;

                currentlyHeldObject.transform.position = Vector3.Lerp(currentlyHeldObject.transform.position,
                    holdPosition, Time.deltaTime * moveSpeed);
                currentlyHeldObject.transform.rotation = Quaternion.Lerp(currentlyHeldObject.transform.rotation,
                    holdRotation, Time.deltaTime * moveSpeed);
            }
        }
    }
}