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

    void OnTriggerEnter2D(Collider2D other )
    {
        // Ignore self or player if needed
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GameManager.Instance.PointsUp(1);
        }
        return;

       
    }
    // Update is called once per frame
    void Update()
    {

    }
}
