using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage = 20f; // Player's attack damage
    public float attackRange = 1f; // Range of the player's attack

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            PerformAttack();
        }
    }

    private void PerformAttack()
    {
        // Get all colliders within the attack range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

        // Iterate through each collider
        foreach (var hitCollider in hitColliders)
        {
            // Check if the collider is an enemy
            if (hitCollider.CompareTag("Enemy"))
            {
                // Get the EnemyHealth component from the enemy
                EnemyHealth enemyHealth = hitCollider.GetComponent<EnemyHealth>();

                // If the enemy has health, apply damage
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(attackDamage);
                }
            }
        }
    }
}
