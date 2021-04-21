using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.I))
        {
            Takedamage(20);
        }

        if (currentHealth == 0)
        {
            Death(0);
        }
     }
    void Takedamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
    }

    void BackToScene(string Scene)
    {
        
        SceneManager.LoadScene(Scene);
    }
    void Death(int damage)
    {
        if (currentHealth == 0)
        {
            BackToScene("RoundhouseScene");
            currentHealth = 100;
        }
    }




}

