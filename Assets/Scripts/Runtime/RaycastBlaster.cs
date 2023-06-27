using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class RaycastBlaster : MonoBehaviour
    {
        [SerializeField]
        private ARRaycastManager raycastManager;

        /// <summary>
        /// List of raycast hits. The list gets populated every time so new list allocations can be avoided.
        /// </summary>
        private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
        private Vector2 screenCenter;

        public void FireRaycast()
        {
            if (raycastManager.Raycast(screenCenter, raycastHits, ARSubsystems.TrackableType.AllTypes))
            {
                HandleRaycasts(raycastHits);
            }
        }

        private void OnEnable()
        {
            screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        }

        private void HandleRaycasts(List<ARRaycastHit> raycastHits)
        {
            foreach (var hit in raycastHits)
            {
                // Does this raycast hit a plane?
                if ((hit.hitType & ARSubsystems.TrackableType.Planes) != 0)
                {
                    Debug.Log("<color=green> Hit </color> a plane with id " + hit.trackableId.ToString());
                }
                else
                {
                    // Raycast hit another type of object.
                    Debug.Log("<color=yellow> Hit </color> an object with type " + hit.hitType);
                }
            }
        }
    }
}
