/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EmilyHealth : MonoBehaviour
{
    private HealthManager healthMan;
    public Slider healthBar;
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
    }


    void Update()
    {
        healthBar.maxValue = healthMan.maxHealth;
        healthBar.value = healthMan.currentHealth;
    }
}*/
