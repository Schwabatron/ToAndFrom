using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Variables (Properties)
    public float moveSpeed = 8f; // enemy's speed
    public Vector2 moveDirection = Vector2.left; // Default movement direction
    public Transform patrolPoints; // Optional patrol points
    private int currentPatrolPointIndex = 0; // Index of the current patrol point

    void Update()
    {
        // If there are patrols points, there are movements
        if (patrolPoints.Length > 0))
        {
            Patrol();
        }
        else
        {
            // Movement procceds in specificed direction
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    private void Patrol()
    {
        // Gets the current patrol point
        Transform targetPoint = patrolPoints[currentPatrolPointIndex];

        // Move towards patrol point
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
        }
    }
}
