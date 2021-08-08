using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float speed, bulletForce;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(
            mouse.x - transform.position.x,
            mouse.y - transform.position.y
        );
        transform.up = direction;
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed * Time.fixedDeltaTime;
    }

    private void Shoot()
    {
        GameObject g = Instantiate(bullet, firePoint.position, transform.rotation);
        Rigidbody2D r = g.GetComponent<Rigidbody2D>();
        r.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}