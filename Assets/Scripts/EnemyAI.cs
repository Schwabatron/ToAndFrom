using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5.0f;
    private float distance;
    private Transform nearestPlayer;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        DetectNearestPlayer();

        distance = Vector2.Distance(transform.position, nearestPlayer.transform.position);
        Vector2 direction = nearestPlayer.transform.position - transform.position;
        
        transform.position = Vector2.MoveTowards(this.transform.position, nearestPlayer.transform.position, speed * Time.deltaTime);
        
        animator.SetFloat("Move X", direction.x);
        animator.SetFloat("Move Y", direction.y);
    }

    void DetectNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        float closestDistance = Mathf.Infinity;
        nearestPlayer = null;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestPlayer = player.transform;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Touched player");
            other.GetComponent<PlayerLife>().Die();
        }
    }
}
