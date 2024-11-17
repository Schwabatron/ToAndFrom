using UnityEngine;

public class Character2Movement : MonoBehaviour
{
    public float moveSpeed = 4f; //set default move speed for the player opon a key press
    private Rigidbody2D rb; //rigidbody(the player)
    private Vector2 movement; // 2d vector movement
    private SpriteRenderer spriteRenderer;
    Animator animator; //declaring animator 
    private bool canAttack = true;

    private string character_direction = "right";
    
    private float attackCooldown = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
   
    void Update()
    {
        // Get input from IJKL keys
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
            character_direction = "right";
            movement.x = 1;
            animator.SetFloat("Move X", movement.x);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            character_direction = "left";
            movement.x = -1;
            animator.SetFloat("Move X", movement.x);
            spriteRenderer.flipX = false;
        }

        movement.Normalize(); //prevents speedboost when diagonal movement 

        if (Input.GetKey(KeyCode.O) && canAttack)
        {
            PerformAttack();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Moving character position
    }

    void PerformAttack()
    {
        if (!canAttack) return;

        animator.SetTrigger("Attack"); // Trigger the attack animation
        canAttack = false; // Prevent further attacks until cooldown

        Invoke("ResetAttackCooldown", attackCooldown); // Start cooldown timer
    }

    public void ExecuteAttack()
    {
        Vector2 attackPosition = rb.position;

        switch (character_direction)
        {
            case "right":
                attackPosition += Vector2.right;
                break;
            case "left":
                attackPosition += Vector2.left;
                break;
        }

        Collider2D[] hitObjects = Physics2D.OverlapBoxAll(attackPosition, new Vector2(1, 1), 0);

        foreach (Collider2D obj in hitObjects)
        {
            if (obj.CompareTag("Player"))
            {
                Destroy(obj.gameObject);
            }
        }

        Debug.Log("Attack executed at " + attackPosition);
    }

    void ResetAttackCooldown()
    {
        canAttack = true; 
    }
}
