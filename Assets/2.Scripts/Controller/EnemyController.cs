using System.Collections;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour, IDamageable
{
    protected float _hp;
    protected float _speed;

    public virtual void GetDamage(int damage)
    {
        _hp -= damage;
        if(_hp <= 0)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
            GameManager.Instance.Score++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Shot"))
        {
            GetDamage(5);
            collision.gameObject.SetActive(false);
        }
    }

    protected abstract void Move();
    protected abstract IEnumerator CoDeactivate();
}
