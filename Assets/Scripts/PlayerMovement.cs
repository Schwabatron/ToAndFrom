using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    // Variables (Properties)
    public float sprintSpeed = 4f; // Speed at which player sprints
    public float walkSpeed = 5f; // Speed at which player moves
    public float mouseSensitivity = 2f; // Affects how fast the player rotates based on mouse movement
    public float jumpForce = 5f; // Determines and controls the upward force applied when jumping

    private Rigidbody rb; // Physics interactions
    private float playerSpeed; // Variable that changes between walking and sprinting speed
    private float yRotation; // Tracks the player’s rotation in the Y-axis (left/right rotation)

    void Start() // Start method
    {
        playerSpeed = walkSpeed;
        rb = GetComponent<Rigidbody>(); 
        // Gets the rigidbody component attached to the player, used for realistic movement and jumping
    }

    void Update() // Makes sure the player’s actions are working properly
    {
        HandleRotation();
        HandleMovement();
        HandleJump();
    }

    private void HandleRotation()
    {
        // Mouse rotation logic for left/right rotation (y-axis)
        yRotation += Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.localEulerAngles = new Vector3(0, yRotation, 0);
    }

    private void HandleMovement()
    { 
        // Receive input from keyboard (Either WASD or Arrow Keys)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // Creates vector movement based upon input
        Vector3 moveDirection = (transform.right * moveX + transform.forward * moveZ).normalized;

        // Check if LeftShift is pressed, change player speed to sprintSpeed, else walkSpeed
        playerSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        // Apply movement to Rigidbody
        Vector3 velocity = moveDirection * playerSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z); // Keep the current y velocity for jumping
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {   
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    { 
        // Cast a ray downwards to check if the player is grounded
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}