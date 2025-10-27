using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CollisionDetect : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;
    [SerializeField] AudioSource collisonFX;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject fadeOut;
 
    
    void OnTriggerEnter(Collider other)
    {
        PlayerMovement pm = thePlayer.GetComponent<PlayerMovement>();
        if (pm != null && pm.isInvulnerable)
        {
            return;
        }
        StartCoroutine(CollisionEnd());
    }

    IEnumerator CollisionEnd()
    {
        collisonFX.Play();
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        mainCam.GetComponent<Animator>().Play("CollisionCam");
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);

    }
}
