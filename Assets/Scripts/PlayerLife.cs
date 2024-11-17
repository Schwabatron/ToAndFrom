using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public bool life = true;

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
         SceneManager.LoadScene("Death");
      }
   }

    public void Die()
    {
        life = false;
        Destroy(gameObject);
        CheckForGameOver();
        Debug.Log("Die has been run");
    }
}
