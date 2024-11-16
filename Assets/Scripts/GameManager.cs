using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;

    public void EndGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
