using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public soHealth health;
    public Text healthText;
    private string healthStyle;

    private void Start() 
    {
        healthSlider.maxValue = health.maxHealth;
        healthSlider.value = health.maxHealth;
    }
    
    private void Update() 
    {
        healthSlider.maxValue = health.maxHealth;
        healthSlider.value = health.health;
        healthText.text = health.health.ToString() + " / " + health.maxHealth.ToString();
    }

}
