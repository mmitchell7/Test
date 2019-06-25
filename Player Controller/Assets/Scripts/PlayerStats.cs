using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public float speed;
    private float defaultSpeed = 6.0f;
    private int maxHealth = 100;
    public float speedMulti;


    public void increaseHealth(int incHealth)
    {
        //increase health
        health += incHealth;
        //if we exceed max health, reset to max
        if (health > maxHealth )
        {
            health = maxHealth;
        }
    }
    public void UpdateSpeed(int cooldown)
    {
        speed = defaultSpeed *= speedMulti;
        StartCoroutine(SpeedCoolDown(cooldown));
       
    }

    public void ResetSpeed()
    {
        speed = defaultSpeed;
    }
    IEnumerator SpeedCoolDown(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ResetSpeed();
    }
}
