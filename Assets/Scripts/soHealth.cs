using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "soHealth", menuName = "battleData/soHealth", order = 0)]
public class soHealth : ScriptableObject {
    
    private int _health;
    private int _maxHealth;
    
    public int health => _health;
    public int maxHealth => _maxHealth;

    public void ChangeBy(int changeBy)
    {
        _health += changeBy;
    }

    public void SetHealth(int setAmount)
    {
        _health = setAmount;
    }

    public void SetMax(int setAmount)
    {
        _maxHealth = setAmount;
    }

    public void Reset()
    {
        SetMax(0);
        SetHealth(0);
    }

}
