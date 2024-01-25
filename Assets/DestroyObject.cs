using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x <= -9.5f)
        {
            Destroy(gameObject);
        }
    }
}
