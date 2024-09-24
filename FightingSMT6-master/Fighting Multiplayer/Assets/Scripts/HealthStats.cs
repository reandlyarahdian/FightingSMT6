using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int CurrentHealth;

    public GameObject health1, health2;
    public HealthBar healthBar;

    public bool GameDeath = false;

    // Start is called before the first frame update
    public void SetupBehaviour()
    {
        SetupHealth();
        SetupMaxHealth();
    }

    private void SetupHealth()
    {
        SetupBar();
    }

    private void SetupMaxHealth()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        CurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void UpdateHealth(int i)
    {
        CurrentHealth -= i;
        healthBar.SetCurrentHealth(CurrentHealth);
        if (CurrentHealth <= 0 && health1.activeInHierarchy)
        {
            UpdateBar();
        }else if (CurrentHealth <= 0)
        {
            GameDeath = true;
        }
    }


    public void UpdateBar()
    {
        health1.SetActive(false);
        healthBar = health2.GetComponent<HealthBar>();
        health2.SetActive(true);
        SetupMaxHealth();
    }

    public int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void SetupBar()
    {
        health1.SetActive(true);
        healthBar = health1.GetComponent<HealthBar>();
    }
}
