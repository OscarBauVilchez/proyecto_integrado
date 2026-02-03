using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 2f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = transform.right * speed;
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Ignore self or player if needed
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        return;

       
    }
    // Update is called once per frame
    void Update()
    {

    }
}
