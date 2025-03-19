using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemies;

    GameObject EnemyPool;

    float _coolTime = 0f;
    const float _interval = 1f;
    const int _spawnCount = 3;

    void Start()
    {
        if (EnemyPool == null)
        {
            EnemyPool = new GameObject("EnemyPool");
        }
    }

    void Update()
    {
        _coolTime += Time.deltaTime;
        if (_coolTime >= _interval)
        {
            _coolTime = 0;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            int rand = Random.Range(0, Enemies.Length);
            GameObject enemy = Instantiate(Enemies[rand], new Vector3(Random.Range(-4f, 4f), 10f, 0), Quaternion.identity);
            enemy.transform.parent = EnemyPool.transform;
        }
    }
}
