using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    /// <summary>
    /// Sunflower seeds initialisation
    /// </summary>
    public List<GameObject> sunflowerSeedObjects;
    public GameObject sunflowerSeedObject;
    public int sunflowerSeedNumberToPool;

    /// <summary>
    /// Bombs initialisaton
    /// </summary>
    public List<GameObject> bombObjects;
    public GameObject bombObject;
    public int bombNumberToPool; 

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SunflowerSeedsPool();
        BombsPool();
    }

    private void SunflowerSeedsPool()
    {
        sunflowerSeedObjects = new List<GameObject>();
        GameObject sunflowerSeeds;
        for(int i = 0; i < sunflowerSeedNumberToPool; i++)
        {
            sunflowerSeeds = Instantiate(sunflowerSeedObject);
            sunflowerSeeds.SetActive(false);
            sunflowerSeedObjects.Add(sunflowerSeeds);
        }
    }

    public GameObject GetSunflowerSeedObject()
    {
        for(int i = 0; i < sunflowerSeedNumberToPool; i++)
        {
            if(!sunflowerSeedObjects[i].activeInHierarchy)
            {
                return sunflowerSeedObjects[i];
            }
        }
        return null;
    }

    private void BombsPool()
    {
        bombObjects = new List<GameObject>();
        GameObject bombs;
        for(int i = 0; i < bombNumberToPool; i++)
        {
            bombs = Instantiate(bombObject);
            bombs.SetActive(false);
            bombObjects.Add(bombs);
        }
    }

    public GameObject GetBombObject()
    {
        for(int i = 0; i < bombNumberToPool; i++)
        {
            if(!bombObjects[i].activeInHierarchy)
            {
                return bombObjects[i];
            }
        }
        return null;
    }
}   
