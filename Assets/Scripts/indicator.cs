using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class indicator : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject visual;

    
    // Start is called before the first frame update
    void Start()
    {
        //get the components
        raycastManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        //hide the placement indicator visual
        visual.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //shoot a raycast from the centre of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        //if we hit an AR plane surface, update the position and rotation
        if(hits.Count > 0)
        {
            //position the indicator where the raycast hit
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            //enable the visual if it's disabled
            if(!visual.activeInHierarchy)
                visual.SetActive(true);
        }
    }
}
