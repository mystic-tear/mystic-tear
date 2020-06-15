using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class ARBattle : MonoBehaviour
{
    private GameObject gameObjectToInstantiate;

    private GameObject spawnedObject;

    [SerializeField]
    private int maxAllowableCreatures = 2;
    private int spawnedCreaturesCount = 0;
    private List<GameObject> placedGameObjectsList = new List<GameObject>();
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();

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
            //spawnedObject.transform.position = hitPose.position;
        }

        if(spawnedCreaturesCount == maxAllowableCreatures)
        {
            battleStart(placedGameObjectsList);
        }
    }
    
    private void battleStart(List<GameObject> placedGameObjects)
    {
        var creature1 = placedGameObjects[0];
        var creature2 = placedGameObjects[1];

        creature1.AddComponent<CreatureHealth>();
        
        creature2.tag = "bad";
        creature2.AddComponent<EnemyHealth>();
        creature2.AddComponent<EnemyFollow>();

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
}
