using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float JetpacForce = 75.0f;
    private Rigidbody2D playerRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        bool JetpacActive = Input.GetButton("Jump");
        if (JetpacActive)
        {
            playerRigidbody.AddForce(new Vector2(0, JetpacForce));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
