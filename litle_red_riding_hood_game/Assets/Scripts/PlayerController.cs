using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jetpackForce = 2.0f;
    private Rigidbody2D playerRb;
    public Vector2 direccion = Vector2.right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();
    }
    void Movement() 
    {
        playerRb.linearVelocity = new Vector2(speed, playerRb.linearVelocity.y);
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jetpackForce, ForceMode2D.Impulse);
        }
    }
    #region Input methods
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Jump();
        }
    }

    #endregion

}
