using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARSingleCtrl : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        AndroidManager.HapticFeedback();
        SceneManager.LoadScene(sceneName);
    }
}
