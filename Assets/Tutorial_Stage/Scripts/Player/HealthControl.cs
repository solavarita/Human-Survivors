using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    [SerializeField] private float healthPercent;
    [SerializeField] private Text healthText;
    [SerializeField] private Slider healthSlider;

    private void Update()
    {       
        HealthUpdate();        
        PercentHealthUpdate();        
    }

    private void HealthUpdate()
    {
        maxHealth = PlayerMovement.Instance.playerMaxHealth;
        currentHealth = PlayerMovement.Instance.playerCurHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    private void PercentHealthUpdate()
    {
        float totalHealth = PlayerMovement.Instance.playerMaxHealth;
        float leftHealth = PlayerMovement.Instance.playerCurHealth;
        float percent = (leftHealth / maxHealth) * 100  ;        
        healthText.text = percent.ToString() + "%";
    }

}
