using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    //Starts at max health
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //adjusts value of health bar to whatever we set
   public void SetHealth(int health)
    {
        slider.value = health;
    }
}
