using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segement;
    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;
    public GameObject obstaclePrefab;


    void Update()
    {
        if (creatingSegment == false)
        { 
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, segement.Length);
        GameObject newSegment = Instantiate(segement[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);

        float[] lanePositions = { -7f, -4f, -1f };

        int obstacleCount = Random.Range(6, 10); 
        for (int i = 0; i < obstacleCount; i++)
        {
        
            float laneX = lanePositions[Random.Range(0, lanePositions.Length)];

      
            float zOffset = Random.Range(5f, 45f);

            Vector3 spawnPos = new Vector3(laneX, -5f, zPos + zOffset);

            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        }

        zPos += 50;
        yield return new WaitForSeconds(3);
        creatingSegment = false;
    }
}
