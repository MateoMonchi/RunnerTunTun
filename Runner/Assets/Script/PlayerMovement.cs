using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2;
    public float horizontalSpeed = 3;
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;

    public float jumpHeight = 2f;
    public float jumpSpeed = 5f;
    private bool isJumping = false;
    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartCoroutine(JumpArcade());
        }
    }

    IEnumerator JumpArcade()
    {
        isJumping = true;
        float peakY = startY + jumpHeight;

        while (transform.position.y < peakY)
        {
            transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
            yield return null;
        }

        while (transform.position.y > startY)
        {
            transform.Translate(Vector3.down * jumpSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        isJumping = false;
    }
}


