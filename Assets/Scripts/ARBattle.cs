<<<<<<< HEAD
﻿﻿using System.Collections;
=======
<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.Collections;
=======
﻿﻿using System.Collections;
>>>>>>> androidDebugging
>>>>>>> master
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARPlaneManager))]

public class ARBattle : MonoBehaviour
{
    private GameObject gameObjectToInstantiate;
    private GameObject spawnedObject;
<<<<<<< HEAD
    private int healthAmount = 100;
    private int enemyMaxHealth = 500;
=======
<<<<<<< HEAD
=======
    private int healthAmount = 100;
    private int enemyMaxHealth = 5000;
>>>>>>> androidDebugging
>>>>>>> master
    private int maxAllowableCreatures = 5;
    private int spawnedCreaturesCount = 0;
    private List<GameObject> placedGameObjectsList = new List<GameObject>();
    private ARRaycastManager _arRaycastManager;
    private ARPlaneManager _arPlaneManager;
<<<<<<< HEAD
    //private Vector2 touchPosition;
=======
<<<<<<< HEAD
    private bool detectPlanes;
    private bool planesAreVisible;
    private Vector2 touchPosition;
>>>>>>> master

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    public soHealth playerHealth;
    public soHealth enemyHealth;
    
<<<<<<< HEAD
=======
    
    // Start is called before the first frame update
=======
    //private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    public soHealth playerHealth;
    public soHealth enemyHealth;
    
>>>>>>> androidDebugging
>>>>>>> master
    private void Awake()
    {
        _arPlaneManager = GetComponent<ARPlaneManager>();
        _arRaycastManager = GetComponent<ARRaycastManager>();

<<<<<<< HEAD
        playerHealth.Reset();
        enemyHealth.Reset();
        //playerHealth.health = playerHealth.maxHealth;
        //enemyHealth.health = enemyHealth.maxHealth;
=======
<<<<<<< HEAD
        currentCreaturesHealth = maxCreaturesHealth;
        creaturesHealthBar.SetMaxHealth(maxCreaturesHealth);
        currentEnemyHealth = maxEnemyHealth;
        enemyHealthBar.SetMaxHealth(maxEnemyHealth);
        Debug.Log("I'm ARBattle : Awake : maxCreaturespawn =" + maxAllowableCreatures);

=======
        playerHealth.health = playerHealth.maxHealth;
        enemyHealth.health = enemyHealth.maxHealth;
>>>>>>> androidDebugging
>>>>>>> master
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

<<<<<<< HEAD
=======
<<<<<<< HEAD
    // Update is called once per frame
=======
>>>>>>> androidDebugging
>>>>>>> master
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
<<<<<<< HEAD

        if(placedGameObjectsList[4] && (enemyHealth.health <= 0))
        {
            placedGameObjectsList[4].gameObject.SetActive(false);
        }
=======
<<<<<<< HEAD
=======

        if(placedGameObjectsList[4] && (enemyHealth.health <= 0))
        {
            Destroy(placedGameObjectsList[4]);
        }
>>>>>>> androidDebugging
>>>>>>> master
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
<<<<<<< HEAD
=======
<<<<<<< HEAD
        Debug.Log("I'm ARBattle : spawnCreature : tag first =" + spawnedObject.tag);
=======
>>>>>>> androidDebugging
>>>>>>> master
        
        spawnedCreaturesCount++;

        if(spawnedCreaturesCount != maxAllowableCreatures)
        {
<<<<<<< HEAD
            playerHealth.ChangeBy(healthAmount);
            playerHealth.maxHealth += healthAmount;
=======
<<<<<<< HEAD
            maxCreaturesHealth += 100;
            currentCreaturesHealth = maxCreaturesHealth;
            creaturesHealthBar.SetMaxHealth(maxCreaturesHealth);
            creaturesHealthBar.SetHealth(currentCreaturesHealth);

=======
            playerHealth.ChangeBy(healthAmount);
            playerHealth.maxHealth += healthAmount;
>>>>>>> androidDebugging
>>>>>>> master
        }
        
        if(spawnedCreaturesCount == maxAllowableCreatures)
        {
            spawnedObject.tag = "bad";
<<<<<<< HEAD
            enemyHealth.maxHealth = enemyMaxHealth;
            enemyHealth.health = enemyHealth.maxHealth;
            PlaneToggle(false);
=======
<<<<<<< HEAD
            maxEnemyHealth += 100;
            currentEnemyHealth = maxEnemyHealth;
            enemyHealthBar.SetMaxHealth(maxEnemyHealth);
            enemyHealthBar.SetHealth(currentEnemyHealth);
            PlaneToggle();
            TrackingToggle();
>>>>>>> master
        }

    }

    public void PlaneToggle(bool flag)
    {
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag ("plane"))
        {
            Renderer r = plane.GetComponent<Renderer>();
            ARPlaneMeshVisualizer t = plane.GetComponent<ARPlaneMeshVisualizer>();
            r.enabled = flag;
            t.enabled = flag;
        }
    }

}
=======
﻿using System.Collections;
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
>>>>>>> master
=======
            enemyHealth.maxHealth = enemyMaxHealth;
            enemyHealth.health = enemyHealth.maxHealth;
            PlaneToggle(false);
        }

    }

    public void PlaneToggle(bool flag)
    {
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag ("plane"))
        {
            Renderer r = plane.GetComponent<Renderer>();
            ARPlaneMeshVisualizer t = plane.GetComponent<ARPlaneMeshVisualizer>();
            r.enabled = flag;
            t.enabled = flag;
        }
    }

}
>>>>>>> androidDebugging
