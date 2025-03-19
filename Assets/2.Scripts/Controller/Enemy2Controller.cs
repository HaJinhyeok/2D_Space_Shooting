using System.Collections;
using UnityEngine;

public class Enemy2Controller : EnemyController
{
    int _movingFlag = 1;

    void Start()
    {
        _speed = 5f;
    }

    private void OnEnable()
    {
        _hp = 15f;
        //StartCoroutine(CoDeactivate());
        Destroy(gameObject, 10f);
        if (transform.position.x >= 0)
        {
            _movingFlag = 1;
        }
        else
        {
            _movingFlag = -1;
        }
    }

    void Update()
    {
        Move();
    }

    protected override void Move()
    {
        Vector3 movement = new Vector3(_movingFlag, -1, 0);
        transform.Translate(movement.normalized * _speed * Time.deltaTime);
        Vector2 pos = transform.position;
        // 화면 밖으로 나가지 않도록 flag 조절
        if (transform.position.x < -4 || transform.position.x > 4)
        {
            _movingFlag *= -1;
        }
        pos.x = Mathf.Clamp(pos.x, -4, 4);
        transform.position = pos; ;
    }

    protected override IEnumerator CoDeactivate()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }
}
