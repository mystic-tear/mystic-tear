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
        if(myTeam.team.Count == 0)
        {
            foreach(Button button in teamButtons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {  
        if(myTeam.team.Count != 0)
        {
            for (int i = 0; i < 5; i++)
            {
                if (myTeam.team[i] == null)
                {
                    teamButtons[i].gameObject.SetActive(false);
                }
                else
                {
                    teamButtons[i].GetComponent<Image>().sprite = myTeam.team[i].GetComponent<IconImage>().image;
                    teamButtons[i].gameObject.SetActive(true);
                }
            }
        }
    }
}
