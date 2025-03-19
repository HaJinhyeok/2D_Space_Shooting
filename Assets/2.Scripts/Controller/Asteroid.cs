using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        if (_rigidbody2D == null)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        StartCoroutine(CoDeactivate());
        Vector2 direction = (Player.Instance.gameObject.transform.position - transform.position).normalized;
        _rigidbody2D.AddForce(direction * 300f);
        _rigidbody2D.AddTorque(30 * Mathf.Deg2Rad);
    }

    IEnumerator CoDeactivate()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }

}
