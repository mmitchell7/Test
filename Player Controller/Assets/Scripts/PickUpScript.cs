using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public enum PickupType
    {
        health,
        speed
    }
    public PickupType myType;




    public int healthValue;
    public float speedMultiValue;
    public int coolDownValue = 3;
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = col.gameObject;
            switch (myType)
            {
                case PickupType.health:
                    //apply health
                    player.GetComponent<PlayerStats>().increaseHealth(healthValue);
                    break;
                case PickupType.speed:
                    player.GetComponent<PlayerStats>().speedMulti = speedMultiValue;
                    player.GetComponent<PlayerStats>().UpdateSpeed(coolDownValue);
                    break;

            }
            Destroy(gameObject);
        }
    }
}
