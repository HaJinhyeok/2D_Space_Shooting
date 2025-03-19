using UnityEngine;

public class BossShotController : MonoBehaviour
{
    float _speed = 6f;
    Vector2 _direction;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }
}
