﻿using System.Collections;
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
    private int healthAmount = 100;
    private int enemyMaxHealth = 500;
    private int maxAllowableCreatures = 5;
    private int spawnedCreaturesCount = 0;
    public List<GameObject> placedGameObjectsList = new List<GameObject>();
    private ARRaycastManager _arRaycastManager;
    private ARPlaneManager _arPlaneManager;
    //private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    public soHealth playerHealth;
    public soHealth enemyHealth;
    
    private void Awake()
    {
        _arPlaneManager = GetComponent<ARPlaneManager>();
        _arRaycastManager = GetComponent<ARRaycastManager>();

        playerHealth.Reset();
        enemyHealth.Reset();
        //playerHealth.health = playerHealth.maxHealth;
        //enemyHealth.health = enemyHealth.maxHealth;
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

        if(spawnedCreaturesCount < maxAllowableCreatures)
        {
            playerHealth.ChangeBy(healthAmount);
            playerHealth.maxHealth += healthAmount;
        }
        
        if(spawnedCreaturesCount == maxAllowableCreatures)
        {
            spawnedObject.tag = "bad";
            spawnedObject.GetComponent<Rigidbody>().mass = 100000000F;
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
