using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth;
    public int maxArmor;

    private int health;
    private int armor;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {

        }
    }

    public void PlayerDamage(int damage)
    {
        if (armor > 0)
        {
            if (armor >= damage )
            {
                armor -= damage;
            } else if (armor < damage)
            {
                int remainigDamage = damage - armor;
                armor = 0;
                health -= remainigDamage;
            }
        } else
        {
            health -= damage;
        }

       if (health <= 0)
       {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
       }
    }

    public void GiveHealth(int amount, GameObject gameObject)
    {
       if (health < maxHealth)
        {
            health += amount;
            Destroy(gameObject);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void GiveArmor(int amount, GameObject gameObject)
    {
        if (armor < maxArmor)
        {
            armor += amount;
            Destroy(gameObject);
        }

        if (armor > maxArmor)
        {
            armor = maxArmor;
        }
    }
}
