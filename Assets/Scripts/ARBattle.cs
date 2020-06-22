<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.Collections;
=======
﻿﻿using System.Collections;
>>>>>>> androidDebugging
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
=======
    private int healthAmount = 100;
    private int enemyMaxHealth = 5000;
>>>>>>> androidDebugging
    private int maxAllowableCreatures = 5;
    private int spawnedCreaturesCount = 0;
    private List<GameObject> placedGameObjectsList = new List<GameObject>();
    private ARRaycastManager _arRaycastManager;
    private ARPlaneManager _arPlaneManager;
<<<<<<< HEAD
    private bool detectPlanes;
    private bool planesAreVisible;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    public int maxCreaturesHealth;
    public int currentCreaturesHealth;
    public HealthBar creaturesHealthBar;
    public int maxEnemyHealth;
    public int currentEnemyHealth;
    public HealthBar enemyHealthBar;
    
    
    // Start is called before the first frame update
=======
    //private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    public soHealth playerHealth;
    public soHealth enemyHealth;
    
>>>>>>> androidDebugging
    private void Awake()
    {
        _arPlaneManager = GetComponent<ARPlaneManager>();
        _arRaycastManager = GetComponent<ARRaycastManager>();

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
    // Update is called once per frame
=======
>>>>>>> androidDebugging
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
=======

        if(placedGameObjectsList[4] && (enemyHealth.health <= 0))
        {
            Destroy(placedGameObjectsList[4]);
        }
>>>>>>> androidDebugging
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
        Debug.Log("I'm ARBattle : spawnCreature : tag first =" + spawnedObject.tag);
=======
>>>>>>> androidDebugging
        
        spawnedCreaturesCount++;

        if(spawnedCreaturesCount != maxAllowableCreatures)
        {
<<<<<<< HEAD
            maxCreaturesHealth += 100;
            currentCreaturesHealth = maxCreaturesHealth;
            creaturesHealthBar.SetMaxHealth(maxCreaturesHealth);
            creaturesHealthBar.SetHealth(currentCreaturesHealth);

=======
            playerHealth.ChangeBy(healthAmount);
            playerHealth.maxHealth += healthAmount;
>>>>>>> androidDebugging
        }
        
        if(spawnedCreaturesCount == maxAllowableCreatures)
        {
            spawnedObject.tag = "bad";
<<<<<<< HEAD
            maxEnemyHealth += 100;
            currentEnemyHealth = maxEnemyHealth;
            enemyHealthBar.SetMaxHealth(maxEnemyHealth);
            enemyHealthBar.SetHealth(currentEnemyHealth);
            PlaneToggle();
            TrackingToggle();
        }

        Debug.Log("I'm ARBattle : spawnCreature : tag second =" + spawnedObject.tag);
    }

    public void CreaturesTakeDamage(int damage)
    {
        currentCreaturesHealth -= damage;
        creaturesHealthBar.SetHealth(currentCreaturesHealth);
    }

    public void EnemyTakeDamage(int damage)
    {
        currentEnemyHealth -= damage;
        enemyHealthBar.SetHealth(currentEnemyHealth);
    }

    public void TrackingToggle()
    {
        detectPlanes = !detectPlanes;
        _arPlaneManager.detectionMode = detectPlanes ? PlaneDetectionMode.Horizontal : PlaneDetectionMode.None;
    }

    public void PlaneToggle()
    {
        planesAreVisible = !planesAreVisible;
        _arPlaneManager.planePrefab.SetActive(planesAreVisible);
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
