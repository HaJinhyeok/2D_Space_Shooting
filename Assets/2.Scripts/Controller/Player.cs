using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    #region Singleton
    static Player s_instance = null;
    public static Player Instance
    {
        get
        {
            if (s_instance == null)
                s_instance = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            return s_instance;
        }
    }
    #endregion

    #region hp
    [SerializeField]
    int _hp;

    public Action OnPlayerHpChanged;

    public int Hp
    {
        get { return _hp; }
        set 
        { 
            _hp = value;
            OnPlayerHpChanged?.Invoke();
        }
    }
    #endregion

    float _interval = 0.1f;
    float _coolTime = 0f;

    void Start()
    {
        transform.position = new Vector2(0, -5);
        _hp = 3;
    }

    void Update()
    {
        Move();
        _coolTime += Time.deltaTime;
        if(_coolTime>=_interval)
        {
            _coolTime = 0;

        }
    }

    void Move()
    {
        transform.Translate(UI_Joystick.Direction * 5 * Time.deltaTime);
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -4, 4);
        pos.y = Mathf.Clamp(pos.y, -7, 7);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Asteroid"))
        {
            GetDamage(1);
            // flashwhite coroutine 추가
            collision.gameObject.SetActive(false);
        }
        else if(collision.CompareTag("Enemy"))
        {
            GetDamage(1);
            // flashwhite coroutine 추가?
            //collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("BossShot"))
        {
            GetDamage(1);
            Destroy(collision.gameObject);
        }
    }

    public void GetDamage(int damage)
    {
        Hp -= damage;
    }
}
