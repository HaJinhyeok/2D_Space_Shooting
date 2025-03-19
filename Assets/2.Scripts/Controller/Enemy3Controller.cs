using System.Collections;
using UnityEngine;

public class Enemy3Controller : EnemyController
{
    Transform player;

    void Start()
    {
        player = Player.Instance.transform;
        _speed = 7f;
    }
    private void OnEnable()
    {
        _hp = 10;
    }

    void Update()
    {
        Move();
    }

    protected override void Move()
    {
        if (transform.position.y <= player.position.y)
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
        else
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * _speed * Time.deltaTime);
        }
    }

    protected override IEnumerator CoDeactivate()
    {
        yield return new WaitForSeconds(7f);
        gameObject.SetActive(false);
    }
}
