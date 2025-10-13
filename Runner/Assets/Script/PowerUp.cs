using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 20f;
    public float boostedSpeed = 10f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.ActivatePowerUp(boostedSpeed, duration);
            Destroy(gameObject);
        }
    }
}
