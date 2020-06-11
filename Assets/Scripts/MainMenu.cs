using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using EventSystems = UnityEngine.EventSystems;




public class MainMenu : MonoBehaviour
{

    public void playGame()
    {
        SceneManager.LoadScene("GalleryScene");
    }
    public void options()
    {

    }
    public void exitGame()
    {
        Application.Quit();
    }
}




