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
        if (health.maxLeft)
        {
            healthStyle = health.maxHealth.ToString() + " / " + health.health.ToString();
        } else {
            healthStyle = health.health.ToString() + " / " + health.maxHealth.ToString();
        }
    }
    
    private void Update() 
    {
        healthSlider.maxValue = health.maxHealth;
        healthSlider.value = health.health;
        healthText.text = healthStyle;
    }

}
