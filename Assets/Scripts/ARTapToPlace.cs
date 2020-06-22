using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARPlaneManager))]


public class ARTapToPlace : MonoBehaviour
{
    private GameObject gameObjectToInstantiate;

    private GameObject spawnedObject;

    [SerializeField]
    private int maxAllowableCreatures = 1;
    private int spawnedCreaturesCount;
    private List<GameObject> placedGameObjectsList = new List<GameObject>();
    private ARRaycastManager _arRaycastManager;
    private ARPlaneManager _arPlaneManager;
<<<<<<< HEAD
=======
<<<<<<< HEAD
    private bool detectPlanes;
=======
>>>>>>> androidDebugging
>>>>>>> master
    private bool planesAreVisible;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        _arPlaneManager = GetComponent<ARPlaneManager>();

    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        return;

        if(!IsPointOverUIObject(touchPosition) && _arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            if(spawnedCreaturesCount < maxAllowableCreatures)
            {
                spawnCreature(hitPose);
            }

            if(spawnedCreaturesCount == maxAllowableCreatures)
            {
<<<<<<< HEAD
                PlaneToggle(false);
=======
<<<<<<< HEAD
                PlaneToggle();
                TrackingToggle();
=======
                PlaneToggle(false);
>>>>>>> androidDebugging
>>>>>>> master
            }
            
            //spawnedObject.transform.position = hitPose.position;
        }
    }
    bool IsPointOverUIObject(Vector2 pos)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        return false;

        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void SetGameObjectToSpawn(GameObject gameObject)
    {
        AndroidManager.HapticFeedback();
        gameObjectToInstantiate = gameObject;
    }

    private void spawnCreature(Pose hitPose)
    {
        spawnedObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
        AndroidManager.HapticFeedback();
        placedGameObjectsList.Add(spawnedObject);
        spawnedCreaturesCount++;
    }

<<<<<<< HEAD
    public void PlaneToggle(bool flag)
    {
=======
<<<<<<< HEAD
    public void TrackingToggle()
    {
        detectPlanes = !detectPlanes;
        _arPlaneManager.detectionMode = detectPlanes ? PlaneDetectionMode.Horizontal : PlaneDetectionMode.None;
    }

    public void PlaneToggle()
    {
        planesAreVisible = !planesAreVisible;
        _arPlaneManager.planePrefab.SetActive(planesAreVisible);
=======
    public void PlaneToggle(bool flag)
    {
>>>>>>> master
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag ("plane"))
        {
            Renderer r = plane.GetComponent<Renderer>();
            ARPlaneMeshVisualizer t = plane.GetComponent<ARPlaneMeshVisualizer>();
            r.enabled = flag;
            t.enabled = flag;
        }
<<<<<<< HEAD
=======
>>>>>>> androidDebugging
>>>>>>> master
    }
}
