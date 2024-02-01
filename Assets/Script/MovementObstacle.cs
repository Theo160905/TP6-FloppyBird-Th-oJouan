using UnityEngine;

public class MovementObstacle : MonoBehaviour
{
    private float _speed = 5.0f;

    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
