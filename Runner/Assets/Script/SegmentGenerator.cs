using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    [Header("Rotation Settings")]
    public bool randomRotation = true;

    [Range(0f, 360f)] public float minRotationY = 0f;
    [Range(0f, 360f)] public float maxRotationY = 360f;

    [Range(0f, 360f)] public float minRotationZ = 0f;
    [Range(0f, 360f)] public float maxRotationZ = 360f;

    public GameObject[] segement;
    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;
    public GameObject obstaclePrefab;
    public GameObject powerUpPrefab;
    public GameObject magnetPowerUpPrefab;
    [Range(0f, 1f)]
    public float powerUpSpawnChance = 0.2f;
    public float proteinsSpawnY = -5.0f;
    public float magnetSpawnY = -7.0f;


    Quaternion GetRandomRotation()
    {
        if (!randomRotation)
            return Quaternion.identity;

        float rotY = Random.Range(minRotationY, maxRotationY);
        float rotZ = Random.Range(minRotationZ, maxRotationZ);

        return Quaternion.Euler(0f, rotY, rotZ);
    }


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

        if(Random.value < powerUpSpawnChance)
        {
            List<GameObject> powerUpPool = new List<GameObject>
            {
                powerUpPrefab,      
                magnetPowerUpPrefab  
            };

            GameObject selectedPrefab = powerUpPool[Random.Range(0, powerUpPool.Count)];

            float spawnY;
            if (selectedPrefab == powerUpPrefab)
            {
                spawnY = proteinsSpawnY;
            }
            else 
            {
                spawnY = magnetSpawnY;
            }

            float powerUpLaneX = lanePositions[Random.Range(0, lanePositions.Length)];
            float powerUpZOffset = Random.Range(15f, 35f);
            Vector3 powerUpSpawnPos = new Vector3(powerUpLaneX, spawnY, zPos + powerUpZOffset);
            Instantiate(selectedPrefab, powerUpSpawnPos, GetRandomRotation());

        }

        int obstacleCount = Random.Range(6, 10); 
        for (int i = 0; i < obstacleCount; i++)
        {
        
            float laneX = lanePositions[Random.Range(0, lanePositions.Length)];

      
            float zOffset = Random.Range(5f, 45f);

            Vector3 spawnPos = new Vector3(laneX, -5f, zPos + zOffset);

            Instantiate(obstaclePrefab, spawnPos, GetRandomRotation());

        }

        zPos += 50;
        yield return new WaitForSeconds(3);
        creatingSegment = false;
    }
}
