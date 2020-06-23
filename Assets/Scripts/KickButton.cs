using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickButton : MonoBehaviour
{
    public soTeam myTeam;
    public int slot;

    public void Kick()
    {
        if(myTeam.team[slot])
        {
            myTeam.team.RemoveAt(slot);
            gameObject.SetActive(false);
        }
    }

}
