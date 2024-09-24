using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeedSpawner : MonoBehaviour
{
    public GameObject sunflowerSeed;
    public Transform[] spawnPoints;

    private float timeBetweenSpawns;
    float nextSpawnTime;

    [SerializeField] private float bottomRange = 0.3f;
    [SerializeField] private float topRange = 0.7f; 
    
    void Start()
    {
        sunflowerSeed.transform.Rotate(0f,0f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            GameObject sunflowerSeed = ObjectPool.instance.GetSunflowerSeedObject();
            if (sunflowerSeed != null)
            {
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Vector3 spawnPosition = spawnPoints[randomIndex].position;
                Quaternion spawnRotation = sunflowerSeed.transform.rotation;

                sunflowerSeed.transform.SetPositionAndRotation(spawnPosition, spawnRotation);
                sunflowerSeed.SetActive(true);

                timeBetweenSpawns = Random.Range(bottomRange, topRange);
                nextSpawnTime = Time.time + timeBetweenSpawns;
            }
       }
    }
}
