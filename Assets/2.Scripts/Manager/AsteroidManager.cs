using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public GameObject[] Asteroids;

    GameObject AsteroidPool;
    List<GameObject> AsteroidList = new List<GameObject>();

    float _coolTime = 0;
    float _interval = 2.5f;

    void Start()
    {
        if (AsteroidPool == null)
        {
            AsteroidPool = new GameObject("AsteroidPool");
        }
    }

    void Update()
    {
        _coolTime += Time.deltaTime;
        if (_coolTime >= _interval)
        {
            _coolTime = 0;
            LaunchAsteroid();
        }
    }

    void LaunchAsteroid()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-7f, 7f), 10f, 0);

        for (int i = 0; i < AsteroidList.Count; i++)
        {
            if (!AsteroidList[i].activeSelf)
            {
                AsteroidList[i].SetActive(true);
                AsteroidList[i].transform.position = spawnPos;
                return;
            }
        }
        int rand = Random.Range(0, Asteroids.Length);
        GameObject asteroid = Instantiate(Asteroids[rand], spawnPos, Quaternion.identity);
        AsteroidList.Add(asteroid);
        asteroid.transform.parent = AsteroidPool.transform;
    }
}
