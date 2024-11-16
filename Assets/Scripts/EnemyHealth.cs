using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Enemy health is set to max at start of game
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Subtract damage from current health

        Debug.Log($"{gameObject.name} took {damage} damage. Remaining health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die(); // If health drops to or below zero, enemy dies
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
        Destroy(gameObject); // Destroys the enemy game object when it dies
    }
}



    // Update is called once per frame
    void Update()
    {
        
    }
}
