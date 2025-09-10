using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    private float currentHealth;
    private float maxHealth;
    private float healthPercent;
    [SerializeField] private Text healthText;
    [SerializeField] private Slider healthSlider;

    [SerializeField] private PlayerStats playerStats;

    private void Update()
    {       
        HealthUpdate();        
        PercentHealthUpdate();        
    }

    private void HealthUpdate()
    {
        maxHealth = playerStats.playerMaxHealth;
        currentHealth = playerStats.playerCurHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    private void PercentHealthUpdate()
    {
        float totalHealth = playerStats.playerMaxHealth;
        float leftHealth = playerStats.playerCurHealth;
        float percent = (leftHealth / maxHealth) * 100;        
        healthText.text = percent.ToString() + "%";
    }

}
