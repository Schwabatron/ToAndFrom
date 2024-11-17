using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
   public float moveSpeed = 4f; // Default move speed
   private Rigidbody2D rb; // Rigidbody component
   private Vector2 movement; // Movement vector
   
   private SpriteRenderer spriteRenderer;
   private Animator animator; // Animator component
   
   private bool canAttack = true;
  //private bool isAttacking = false; // Declare isAttacking
   private Vector2 attackDirection;   // Declare attackDirection
   private Vector2 attackPosition;    // Declare attackPosition

   private string character_direction = "right";
   private float attackCooldown = 1f;
   public float attackReach = .5f;    // Distance from the player to the attack area
   public float attackWidth = .05f;      // Width of the attack area
   public float attackHeight = .05f;
    [SerializeField] private AudioClip walkingSoundClip;
    private AudioSource walkingSource;

   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
      spriteRenderer = GetComponent<SpriteRenderer>();
        walkingSource = GetComponent<AudioSource>();
   }

    void Update()
    {
        // Reset movement
        movement.x = 0;
        movement.y = 0;

        animator.SetFloat("Move X", movement.x);
        animator.SetFloat("Move Y", movement.y);

        // Handle input
        if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1;
            animator.SetFloat("Move Y", movement.y);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1;
            animator.SetFloat("Move Y", movement.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            character_direction = "right";
            movement.x = 1;
            animator.SetFloat("Move X", movement.x);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            character_direction = "left";
            movement.x = -1;
            animator.SetFloat("Move X", movement.x);
            spriteRenderer.flipX = false;
        }

        movement.Normalize(); // Prevents speed boost when moving diagonally

        // Play walking sound if the player is moving
        if (movement != Vector2.zero)
        {
            if (!walkingSource.isPlaying)
            {
                walkingSource.clip = walkingSoundClip;
                walkingSource.loop = true;
                walkingSource.Play();
            }
        }
        else
        {
            if (walkingSource.isPlaying && walkingSource.clip == walkingSoundClip)
            {
                walkingSource.Stop();
            }
        }

        if (Input.GetKey(KeyCode.E) && canAttack)
        {
            PerformAttack();
        }
    }
    void FixedUpdate()
   {
      
      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
   }

   void PerformAttack()
   {
      if (!canAttack) return;

      // Prevent movement during attack
      //isAttacking = true;

      // Store attack position and direction
      attackPosition = rb.position;

      switch (character_direction)
      {
         case "right":
            attackDirection = Vector2.right;
            break;
         case "left":
            attackDirection = Vector2.left;
            break;
         default:
            attackDirection = Vector2.zero; // Default to zero if undefined
            break;
      }

      attackPosition += attackDirection * attackReach;
      Debug.Log( attackPosition);

      animator.SetTrigger("Attack");
      canAttack = false;

      Invoke("ResetAttackCooldown", attackCooldown);
   }
   
   void ExecuteAttack()
   {
      // Use the stored attackPosition and attackRange
      Collider2D[] hitObjects = Physics2D.OverlapBoxAll(
         attackPosition,
         new Vector2(attackWidth, attackHeight),
         0
      );

      foreach (Collider2D obj in hitObjects)
      {
         if (obj.CompareTag("Player2")) // Replace "Enemy" with the appropriate tag
         {
            Destroy(obj.gameObject);
         }
      }

      Debug.Log("Attack executed at " + attackPosition);
   }

   void ResetAttackCooldown()
   {
      canAttack = true;
      //isAttacking = false; // Re-enable movement
   }
   
   void OnDrawGizmos()
   {
      if (Application.isPlaying && canAttack == false) // Only show when attacking
      {
         Gizmos.color = Color.red;
         Gizmos.DrawWireCube(attackPosition, new Vector3(attackWidth, attackHeight, 0));
      }
   }
}
