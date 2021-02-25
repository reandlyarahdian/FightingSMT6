using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int CurrentHealth;
    public int damage = 7;
    public PlayerAnimation anim;
    public HealthBar healthBar;
    public GameObject health1, health2;
    public bool health11, health22;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        CurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        health1.SetActive(true);
        health11 = true;
        health22 = false;
        health2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire 3"))
        {
            CurrentHealth = CurrentHealth - 10;
            healthBar.SetCurrentHealth(CurrentHealth);
            Debug.Log("udah kepejet");
        }

        if (health1 == true && CurrentHealth <= 0)
        {
            health1.SetActive(false);
            health11 = false;
            health22 = true;
            health2.SetActive(true);
        }
    }
    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth = CurrentHealth - damage;
        healthBar.SetCurrentHealth(CurrentHealth);
        anim.HitAnimation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BOX")
        {
            TakeDamage(damage);
        }
    }

}
