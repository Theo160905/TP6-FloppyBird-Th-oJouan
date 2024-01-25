using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb; // Reference to the character's Rigidbody2D component
    public float jumpForce = 5f; // The force applied when jumping

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); 
        }
    }
}
