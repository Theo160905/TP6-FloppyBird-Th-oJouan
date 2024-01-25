using UnityEngine;

public class MovementObstacle : MonoBehaviour
{

    public float speed = 2.0f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
