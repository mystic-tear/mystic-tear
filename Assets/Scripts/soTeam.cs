using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "soTeam", menuName = "battleData/soTeam", order = 0)]
public class soTeam : ScriptableObject {
    
    public List<GameObject> team;
    
    public void invite(GameObject member)
    {
        team.Add(member);
    }

    public void kick(GameObject member)
    {
        team.Remove(member);
    }

    public void clean() 
    {
        team.Clear();
    }
}
