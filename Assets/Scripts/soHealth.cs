using UnityEngine;

[CreateAssetMenu(fileName = "soHealth", menuName = "battleData/soHealth", order = 0)]
public class soHealth : ScriptableObject {
    
    private int _health;
    private int _maxHealth;
    
    public int health
    {
        get { return _health; }
        set { _health = value; }
    }

    public int maxHealth 
    {   get { return _maxHealth; }
        set { _maxHealth = value; } 
    }

    public void ChangeBy(int changeBy)
    {
        health += changeBy;
        if(_health <= 0)
        {
            health = 0;
        }
        
    }

    public void Reset()
    {
        health = 0;
        maxHealth = 0;
    }

}
