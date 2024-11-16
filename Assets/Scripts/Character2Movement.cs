using UnityEngine;

public class Character2Movement : MonoBehaviour
{
    public float moveSpeed = 4f; //set default move speed for the player opon a key press
    private Rigidbody2D rb; //rigidbody(the player)
    private Vector2 movement; // 2d vector movement
    private SpriteRenderer spriteRenderer;
    Animator animator; //declaring animator 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
   
    void Update()
    {
        // Get input from WASD keys
        movement.x = 0;
        movement.y = 0;
        
        animator.SetFloat("Move X", movement.x);
        animator.SetFloat("Move Y", movement.y);
        
        if (Input.GetKey(KeyCode.I))
        {
            movement.y = 1;
            animator.SetFloat("Move Y", movement.y);
        }
        else if (Input.GetKey(KeyCode.K))
        {
            movement.y = -1;
            animator.SetFloat("Move Y", movement.y);
        }

        if (Input.GetKey(KeyCode.L))
        {
            movement.x = 1;
            animator.SetFloat("Move X", movement.x);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            movement.x = -1;
            animator.SetFloat("Move X", movement.x);
            spriteRenderer.flipX = false;
        }

        movement.Normalize(); //prevents speedboost when diagnal movement 
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Moving character position
    }
}
