using UnityEngine;

public class MovementObstacle : MonoBehaviour
{

    public float speed = 5.0f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
