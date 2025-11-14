using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPowerUp : MonoBehaviour
{
    public float duration = 10f;

  
    public float magnetRadius = 15f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            
            player.ActivateMagnetPowerUp(duration, magnetRadius);

            
            Destroy(gameObject);
        }
    }
}
