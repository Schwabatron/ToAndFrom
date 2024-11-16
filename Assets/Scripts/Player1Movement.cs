using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
   public float moveSpeed = 8f; //set default move speed for the player opon a key press
   private Rigidbody2D rb; //rigidbody(the player)
   private Vector2 movement; // 2d vector movement

   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
   }
   
   void Update()
   {
      // Get input from WASD keys
      movement.x = 0;
      movement.y = 0;

      if (Input.GetKey(KeyCode.W))
      {
         movement.y = 1;
      }
      else if (Input.GetKey(KeyCode.S))
      {
         movement.y = -1;
      }

      if (Input.GetKey(KeyCode.D))
      {
         movement.x = 1;
      }
      else if (Input.GetKey(KeyCode.A))
      {
         movement.x = -1;
      }

      movement.Normalize(); //prevents speedboost when diagnal movement 
   }

   void FixedUpdate()
   {
      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Moving character position
   }
}