using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;

    public float[] lanePositions = { -3f, 0f, 3f }; 
    private int currentLane = 1; 
    public float laneChangeSpeed = 8f;

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

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 0)
                currentLane--;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < lanePositions.Length - 1)
                currentLane++;
        }

        Vector3 targetPosition = new Vector3(
            lanePositions[currentLane], 
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);

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

