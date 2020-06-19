﻿using UnityEngine;

[CreateAssetMenu(fileName = "soHealth", menuName = "battleData/soHealth", order = 0)]
public class soHealth : ScriptableObject {
    
    private int _health;
    private int _maxHealth;
    
    public int health
    {
        get { return _health; }
        set { _health = value; }
    }

    public int maxHealth { get; set; }

    public void ChangeBy(int changeBy)
    {
        _health += changeBy;
    }

    public void Reset()
    {
        health = 0;
        maxHealth = 0;
    }

}
