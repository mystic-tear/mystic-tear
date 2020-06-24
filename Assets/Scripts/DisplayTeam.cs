using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayTeam : MonoBehaviour
{
    public soTeam myTeam;
    public Button[] teamButtons = new Button[5];
    
    void Start()
    {
        myTeam.clean();
        if(myTeam.team.Count == 0) cleanButtons();
    }

    void Update()
    {  
        refreshTeam();
    }

    public void cleanButtons()
    {
        foreach(Button button in teamButtons)
        {
            button.GetComponentInParent<Canvas>().enabled = false;
        }
    }
    
    private void refreshTeam()
    {        
        if(myTeam.team.Count != 0)
        {
            for (int i = 0; i < myTeam.team.Count; i++)
            {
                if (!myTeam.team[i])
                {
                    teamButtons[i].GetComponentInParent<Canvas>().enabled = false;
                }
                else
                {
                    teamButtons[i].GetComponent<Image>().sprite = myTeam.team[i].GetComponent<IconImage>().image;
                    teamButtons[i].GetComponentInParent<Canvas>().enabled = true;
                }
            }
        }
    }
}
