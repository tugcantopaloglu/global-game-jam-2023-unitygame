using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarBehavior : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public void setHealth(float health, float maxHealth)
    {
        //slider.gameObject.SetActive(health < maxHealth);
        Debug.Log("Health: " + health);
        Debug.Log("MaxHealth" + maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
    
 
}
