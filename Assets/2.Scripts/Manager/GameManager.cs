using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject BossEnemy;

    public bool IsBossTurn = false;

    static GameManager s_instance = null;
    public static GameManager Instance
    {
        get
        {
            if (s_instance == null)
                s_instance = GameObject.Find("Managers").GetComponent<GameManager>();
            return s_instance;
        }
    }

    int _score = 0;
    public Action OnScoreChanged;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            OnScoreChanged?.Invoke();
        }
    }

    public Action OnBossAction;

    void OnBossCome()
    {
        Instantiate(BossEnemy, new Vector3(0, 12, 0), Quaternion.identity);
    }

    void Start()
    {
        OnBossAction += OnBossCome;
    }
}
