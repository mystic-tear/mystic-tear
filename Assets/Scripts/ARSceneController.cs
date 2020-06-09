using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void QuitOnConnectionErrors()
    {
        if (Session.Status ==  SessionStatus.ErrorPermissionNotGranted)
        {
            StartCoroutine(CodelabUtils.ToastAndExit(
              "Camera permission is needed to run this application.", 5));
        }
        else if (Session.Status.IsError())
        {
        // This covers a variety of errors.  See reference for details
        // https://developers.google.com/ar/reference/unity/namespace/GoogleARCore
        StartCoroutine(CodelabUtils.ToastAndExit(
            "ARCore encountered a problem connecting. Please restart the app.", 5));
        }
    }
}
