using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacementWithDraggingAndDroppingController : MonoBehaviour
{
    [SerializeField]
    private GameObject placedPrefab;

    [SerializeField]
    private GameObject welcomePanel;

    [SerializeField]
    private Button dismissButton;

    [SerializeField]
    private Camera arCamera;

    private GameObject placedObject;

    private Vector2 touchPosition = default;

    private ARRaycastManager arRaycastManager;

    private bool onTouchHold = false;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        dismissButton.onClick.AddListener(Dismiss);
    }

    private void Dismiss() => welcomePanel.SetActive(false);

    void Update()
    {
        if (welcomePanel.activeSelf)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.transform.name.Contains("Witch"))
                    {
                        if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                        {
                            onTouchHold = true;
                            Pose hitPose = hits[0].pose;
                            placedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                        }
                    }
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                touchPosition = touch.position;

                if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    if (placedObject == null)
                    {
                        placedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                    }
                    else
                    {
                        placedObject.transform.position = hitPose.position;
                        placedObject.transform.rotation = hitPose.rotation;
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                onTouchHold = false;
            }
        }

        //if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        //{
        //    Pose hitPose = hits[0].pose;

        //    if (placedObject == null)
        //    {
        //        placedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
        //    }
        //    else
        //    {
        //        if (onTouchHold)
        //        {
        //            placedObject.transform.position = hitPose.position;
        //            placedObject.transform.rotation = hitPose.rotation;
        //        }
        //    }
        //}
    }
}


//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.XR.ARFoundation;

//[RequireComponent(typeof(ARRaycastManager))]
//public class PlacementWithDraggingAndDroppingController : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject placedPrefab;

//    [SerializeField]
//    private GameObject welcomePanel;

//    [SerializeField]
//    private Button dismissButton;

//    [SerializeField]
//    private Camera arCamera;

//    [SerializeField]
//    private float defaultRotation = 0;

//    private GameObject placedObject;

//    private Vector2 touchPosition = default;

//    private ARRaycastManager arRaycastManager;

//    //private bool isLocked = false;

//    private bool onTouchHold = false;

//    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

//    void Awake()
//    {
//        arRaycastManager = GetComponent<ARRaycastManager>();
//        dismissButton.onClick.AddListener(Dismiss);

//        //if (lockButton != null)
//        //{
//        //    lockButton.onClick.AddListener(Lock);
//        //}
//    }
//    private void Dismiss() => welcomePanel.SetActive(false);

//    //private void Lock()
//    //{
//    //    isLocked = !isLocked;
//    //    lockButton.GetComponentInChildren<Text>().text = isLocked ? "Locked" : "Unlocked";
//    //    if (placedObject != null)
//    //    {
//    //        placedObject.GetComponent<PlacementObject>()
//    //            .SetOverlayText(isLocked ? "AR Object Locked" : "AR Object Unlocked");
//    //    }
//    //}

//    void Update()
//    {
//        // do not capture events unless the welcome panel is hidden
//        if (welcomePanel.activeSelf)
//            return;

//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);

//            touchPosition = touch.position;

//            if (touch.phase == TouchPhase.Began)
//            {
//                Ray ray = arCamera.ScreenPointToRay(touch.position);
//                RaycastHit hitObject;
//                if (Physics.Raycast(ray, out hitObject))
//                {
//                    if (hitObject.transform.name.Contains("Witch"))
//                    {
//                        onTouchHold = true;
//                    }
//                    //PlacementObject placementObject = hitObject.transform.GetComponent<PlacementObject>();
//                    //if (placementObject != null)
//                    //{
//                    //    onTouchHold = isLocked ? false : true;
//                    //    placementObject.SetOverlayText(isLocked ? "AR Object Locked" : "AR Object Unlocked");
//                    //}
//                }
//            }

//            if (touch.phase == TouchPhase.Ended)
//            {
//                onTouchHold = false;
//            }
//        }

//        if (onTouchHold)
//        {
//            if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
//            {
//                Pose hitPose = hits[0].pose;

//                if (placedObject != null)
//                {
//                    Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
//                }
//                else
//                {
//                    placedObject.transform.position = hitPose.position;
//                    placedObject.transform.rotation = hitPose.rotation;

//                }
//             }
//        }

//        //if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
//        //{
//        //    Pose hitPose = hits[0].pose;

//        //    if (placedObject == null)
//        //    {
//        //        if (defaultRotation > 0)
//        //        {
//        //            placedObject = Instantiate(placedPrefab, hitPose.position, Quaternion.identity);
//        //            placedObject.transform.Rotate(Vector3.up, defaultRotation);
//        //        }
//        //        else
//        //        {
//        //            placedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
//        //        }
//        //    }
//        //    else
//        //    {
//        //        if (onTouchHold)
//        //        {
//        //            placedObject.transform.position = hitPose.position;
//        //            if (defaultRotation == 0)
//        //            {
//        //                placedObject.transform.rotation = hitPose.rotation;
//        //            }
//        //        }
//        //    }
//        //}
//    }
//}
