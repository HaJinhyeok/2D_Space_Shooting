using System.Collections;
using UnityEngine;

public class BossController : EnemyController
{
    public GameObject BossShot;

    Transform player;

    bool _isRotateAttack = false;
    bool _isFollowAttack = false;
    int _follow = 0;
    float _angle = 225;
    float _coolTime = 0;
    const float _interval = 3f;

    void Start()
    {
        _hp = 200;
        player = Player.Instance.transform;
    }

    void Update()
    {
        if (transform.position.y > 6)
        {
            Move();
        }
        else
        {
            _coolTime += Time.deltaTime;
            if (_coolTime >= _interval)
            {
                _coolTime = 0;
                Attack();
            }
        }
    }

    public override void GetDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
            GameManager.Instance.Score += 100;
            // 게임 클리어 화면
            UI_Game.OnGameClearAction?.Invoke();
        }
    }

    void Attack()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            // 1. 360도 회전
            StartCoroutine(CoRotationAttack());
        }
        else
        {
            // 2. 따라가는 총알
            StartCoroutine(CoFollowAttack());
        }
    }

    IEnumerator CoRotationAttack()
    {
        while (_angle != 315)
        {
            GameObject bossShot = Instantiate(BossShot, transform.position, Quaternion.identity);
            Vector2 direction = new Vector2(Mathf.Cos(_angle * Mathf.Deg2Rad), Mathf.Sin(_angle * Mathf.Deg2Rad)).normalized;
            bossShot.GetComponent<BossShotController>().SetDirection(direction);
            _angle += 1;
            yield return new WaitForSeconds(0.2f);

        }
        _angle = 225;
    }

    IEnumerator CoFollowAttack()
    {
        while (_follow != 30)
        {
            GameObject bossShot = Instantiate(BossShot, transform.position, Quaternion.identity);
            Vector2 direction = (Player.Instance.transform.position - transform.position).normalized;
            bossShot.GetComponent<BossShotController>().SetDirection(direction);
            _follow += 1;
            yield return new WaitForSeconds(0.2f);
        }
        _follow = 0;
    }

    protected override void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime);
    }

    protected override IEnumerator CoDeactivate()
    {
        yield return null;
    }
}
