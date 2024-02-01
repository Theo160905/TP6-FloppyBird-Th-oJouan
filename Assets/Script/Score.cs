using UnityEngine;

public class Score : MonoBehaviour
{
    private int _scorePoints = 1;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreText scoreManager = FindObjectOfType<ScoreText>();
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(_scorePoints);
            }
        }
    }
}
