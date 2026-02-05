using UnityEngine;
using UnityEngine.Windows.Speech;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float detectionDistance = 5f;
    public float speed = 3f;
    public float jumpForce = 7f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform obstacleCheck;
    public LayerMask obstacleLayer;

    private Rigidbody2D enemyRb;
    private Animator enemyAnim;
    private bool playerDetected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        DetectObstacle();
    }
    void FixedUpdate()
    {
        if (!playerDetected) 
        {
            MoveLeft();
        }
    }
    void DetectPlayer() 
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= detectionDistance)
        {
            playerDetected = true;
        }
    }
    void MoveLeft()
    {
        enemyRb.linearVelocity = new Vector2(-speed, enemyRb.linearVelocity.y);
    }
    void DetectObstacle()
    {
        if (!playerDetected) 
        {
            bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

            bool obstacleAhead = Physics2D.Raycast(obstacleCheck.position,Vector2.left, 0.5f,obstacleLayer);
            if (isGrounded && obstacleAhead)
            {
                Jump();
            }
        }
        return;

        
    }
    void Jump()
    {
        enemyRb.linearVelocity = new Vector2(enemyRb.linearVelocity.x, jumpForce);
    }
}
