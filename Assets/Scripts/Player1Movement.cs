//using System.Numerics;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{
   public float moveSpeed = 8f; //set default move speed for the player opon a key press
   private Rigidbody2D rb; //rigidbody(the player)
   private Vector2 movement; // 2d vector movement
   Animator animator;

   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
   }
   
   void Update()
   {
      // Get input from WASD keys
      movement.x = 0;
      movement.y = 0;
      //Sets X and Y float values in animator to 0
      animator.SetFloat("Move X", 0);
      animator.SetFloat("Move Y", 0);

      //Changes movement variables and provides directional info to animation controller
      if (Input.GetKey(KeyCode.W))
      {
         movement.y = 1;
         animator.SetFloat("Move Y", 1);
      }
      else if (Input.GetKey(KeyCode.S))
      {
         movement.y = -1;
         animator.SetFloat("Move Y", -1);
      }

      if (Input.GetKey(KeyCode.D))
      {
         movement.x = 1;
         animator.SetFloat("Move X", 1);
      }
      else if (Input.GetKey(KeyCode.A))
      {
         movement.x = -1;
         animator.SetFloat("Move X", -1);
      }

      movement.Normalize(); //prevents speedboost when diagnal movement 
   }

   void FixedUpdate()
   {
      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Moving character position
   }

   //Checks if other players are alive and have the PlayerLife.life boolean set to true
   //If not, loads "Game Over" scene.
   //May move to enemy AI instead
   void CheckForGameOver()
   {
      GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
      bool anyPlayersAlive = false;

      foreach (GameObject player in players)
      {
         PlayerLife playerLife = player.GetComponent<PlayerLife>();
         if (playerLife != null && playerLife.life == true)
         {
            anyPlayersAlive = true;
            break;
         }
      }

      if (!anyPlayersAlive)
      {
         SceneManager.LoadScene("Game Over");
      }
   }

   //Will probably move to EnemyAI script
   //Testing for collision, releads scene on collision with object of name "circle"
   //Remove before game is finalized
   void OnCollisionEnter2D(Collision2D collision)
   {
      Debug.Log(collision.gameObject.name);

      if (collision.gameObject.name == "Circle")
      {
         SceneManager.LoadScene("Game Over");
      }
   }
}