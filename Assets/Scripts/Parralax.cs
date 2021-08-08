using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Parralax : MonoBehaviour
{
    [SerializeField] private float speed, minPosX, maxPosX;
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer[] spriteRenderers;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderers = new SpriteRenderer[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            SpriteRenderer renderer = transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            spriteRenderers[i] = renderer;
        }
        SetRandomSprites();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (transform.position.x <= minPosX)
        {
            SetRandomSprites();
            transform.position = new Vector3(maxPosX, transform.position.y, transform.position.z);
        }
    }

    private void SetRandomSprites()
    {
        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            int rand = Random.Range(0, sprites.Length);
            renderer.sprite = sprites[rand];
        }
    }
}