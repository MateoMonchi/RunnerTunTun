using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFX;
    private Transform playerTransform;
    private bool isAttracted = false;
    public float attractionSpeed = 20f;

    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        MasterInfo.coinCount += 1;
        this.gameObject.SetActive(false);
    }
    public void StartAttraction(Transform target)
    {
        if (!isAttracted)
        {
            playerTransform = target;
            isAttracted = true;
        }
    }
    void Update()
    {
        if (isAttracted && playerTransform != null)
        {
            // Mueve la moneda hacia el jugador
            transform.position = Vector3.MoveTowards(
                transform.position,
                playerTransform.position,
                attractionSpeed * Time.deltaTime
            );

     
        }
    }
}
