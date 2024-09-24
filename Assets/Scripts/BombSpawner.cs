using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bomb;
    public Transform[] spawnPoints;

    private float timeBetweenSpawns;
    float nextSpawnTime;

    [SerializeField] private float bottomRange = 0.8f;
    [SerializeField] private float topRange = 1.3f; 
    
    void Start()
    {
        bomb.transform.Rotate(0f,0f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            GameObject bomb = ObjectPool.instance.GetBombObject();
            if (bomb != null)
                {
                    int randomIndex = Random.Range(0, spawnPoints.Length);
                    Vector3 spawnPosition = spawnPoints[randomIndex].position;
                    Quaternion spawnRotation = bomb.transform.rotation;

                    bomb.transform.SetPositionAndRotation(spawnPosition, spawnRotation);
                    bomb.SetActive(true);

                    timeBetweenSpawns = Random.Range(bottomRange, topRange);
                    nextSpawnTime = Time.time + timeBetweenSpawns;
                }
        }
    }
}
