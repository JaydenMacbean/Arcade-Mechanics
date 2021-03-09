using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public healthbar healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

     void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space))
      {
            Takedamage(20);
        }
    }
    void Takedamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
    }




}

