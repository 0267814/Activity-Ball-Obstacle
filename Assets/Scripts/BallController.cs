using UnityEngine;


public class BallController : MonoBehaviour
{
    
    public float moveSpeed = 5.0f;
    public float turnSpeed = 100.0f;

    
    public float jumpForce = 5.0f;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.6f;

    private Rigidbody rb;
    private float moveInput;
    private float turnInput;
    private bool jumpRequested;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        moveInput = Input.GetAxisRaw("Vertical");     
        turnInput = Input.GetAxisRaw("Horizontal");   

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        ApplyMovement();
        ApplyRotation();
        ApplyJump();
    }

    private void ApplyMovement()
    {
        Vector3 targetVelocity = transform.forward * (moveInput * moveSpeed);

        targetVelocity.y = rb.linearVelocity.y;

        rb.linearVelocity = targetVelocity;
    }

    private void ApplyRotation()
    {
        float turnAmount = turnInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void ApplyJump()
    {
        if (jumpRequested)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequested = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }
}