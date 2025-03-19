using System.Collections;
using UnityEngine;

public class Enemy1Controller : EnemyController
{
    void Start()
    {
        _speed = 3f;
    }

    private void OnEnable()
    {
        _hp = 20;
        //StartCoroutine(CoDeactivate());
        Destroy(gameObject, 6f);
    }

    void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    protected override IEnumerator CoDeactivate()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
