using UnityEngine;

public class GameOver : MonoBehaviour
{   public GameObject gameOverPanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
            Time.timeScale = 0f;
        }
    }
}
