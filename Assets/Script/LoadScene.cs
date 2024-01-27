using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void OnTitleScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName: "Menu");
    }
    public void Game()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
}
