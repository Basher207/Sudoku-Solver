using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SudokuGame
{
    public class GrabbableObject : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// Called when an object is clicked by the user
        /// </summary>
        public static event Action<GrabbableObject> OnGrabbableObjectClicked = delegate { };
        /// <summary>
        /// Called when an object release is requested
        /// </summary>
        public static event Action<GrabbableObject> OnGrabbableObjectReleaseRequested = delegate { };

        [SerializeField] private Rigidbody screenRigidBody;
        [SerializeField] private Collider screenCollider;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnGrabbableObjectClicked.Invoke(this);
        }

        public void ReleaseObjectIfHeld()
        {
            OnGrabbableObjectReleaseRequested.Invoke(this);
        }

        /// <summary>
        /// Grab object
        /// </summary>
        /// <returns>returns true if grabbing it is allowed</returns>
        public virtual bool GrabObject()
        {
            screenRigidBody.isKinematic = true;
            screenCollider.enabled = false;
            return true;
        }
        
        /// <summary>
        /// Release object
        /// </summary>
        public virtual void ReleaseObject()
        {
            screenRigidBody.isKinematic = false;
            screenCollider.enabled = true;
        }
    }
}