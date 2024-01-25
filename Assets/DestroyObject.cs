using UnityEngine;

public class DetruireSurPosition : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x <= -9.5f)
        {
            Destroy(gameObject);
        }
    }
}
