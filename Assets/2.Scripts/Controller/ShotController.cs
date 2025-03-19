using System.Collections;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    float _speed = 5f;

    private void OnEnable()
    {
        StartCoroutine(CoDeactivate());
    }

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    IEnumerator CoDeactivate()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
