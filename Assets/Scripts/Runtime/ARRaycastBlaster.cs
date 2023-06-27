using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class ARRaycastBlaster : MonoBehaviour
    {
        [SerializeField]
        private ARRaycastManager raycastManager;

        [SerializeField]
        private Text logText;

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
                    logText.text += $"Hit a plane with id {hit.trackableId}\n";
                }
                else
                {
                    // Raycast hit another type of object.
                    logText.text += $"Hit a object with type {hit.hitType}\n";
                }
            }
        }
    }
}
