using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public bool life = true;

    void Die()
    {
        life = false;
        Destroy(gameObject);
    }
}
