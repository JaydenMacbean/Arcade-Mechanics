using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P2Damage : MonoBehaviour
{
    public int maxHealth = 100;
    static public int currentHealth;
    public healthbar healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Takedamage(20);
        }

        if (currentHealth == 0)
        {
            Death(0);
        }
    }
    public void Takedamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
    }

    public void BackToScene(string Scene)
    {

        SceneManager.LoadScene(Scene);
    }
    public void Death(int damage)
    {
        if (currentHealth == 0)
        {
            BackToScene("RoundhouseScene");
            currentHealth = 100;
        }
    }
}
