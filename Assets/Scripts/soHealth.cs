<<<<<<< HEAD
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
        if((health += changeBy) <= 0)
        {
            health = 0;
        }
        
        health += changeBy;
    }

    public void Reset()
    {
        health = 0;
        maxHealth = 0;
    }

}
=======
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
        if((_health += changeBy) <= 0)
        {
            _health = 0;
        }
        
        _health += changeBy;
    }

    public void Reset()
    {
        health = 0;
        maxHealth = 0;
    }

}
>>>>>>> master
