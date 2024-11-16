using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    private float length, startPos;
    public float scrollSpeed;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, length);
        transform.position = new Vector3(startPos + newPosition, transform.position.y, transform.position.z);
    }
}
