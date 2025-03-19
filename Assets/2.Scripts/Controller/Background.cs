using UnityEngine;

public class Background : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    float offsetX;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        offsetX += 0.3f * Time.deltaTime;
        spriteRenderer.material.mainTextureOffset = new Vector2(offsetX, 0);
    }
}
