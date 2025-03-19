using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    public GameObject Shot;

    GameObject ShotPool;
    List<GameObject> ShotList = new List<GameObject>();

    float _coolTime = 0;
    float _interval = 0.1f;

    void Start()
    {
        if (ShotPool == null)
        {
            ShotPool = new GameObject("ShotPool");
        }
    }

    void Update()
    {
        _coolTime += Time.deltaTime;
        if (_coolTime >= _interval)
        {
            _coolTime = 0;
            Shooting();
        }
    }

    void Shooting()
    {
        for (int i = 0; i < ShotList.Count; i++)
        {
            if (!ShotList[i].activeSelf)
            {
                ShotList[i].SetActive(true);
                ShotList[i].transform.position = Player.Instance.transform.position + Vector3.up;
                return;
            }
        }
        GameObject shot = Instantiate(Shot, Player.Instance.transform.position + Vector3.up, Quaternion.identity);
        ShotList.Add(shot);
        shot.transform.parent = ShotPool.transform;
    }
}
