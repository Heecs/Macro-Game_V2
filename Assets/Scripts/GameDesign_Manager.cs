using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDesign_Manager : MonoBehaviour
{
    [SerializeField]
    private float gravityMod;

    public GameObject gameOverScreen;
    private void Awake()
    {
        Physics.gravity*=gravityMod;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        print("GameOver");
        gameOverScreen.SetActive(true);
    }

    public void GameWon()
    {
        Time.timeScale = 0;
        print("GameOver");
        gameOverScreen.SetActive(true);
    }

    public void ExitGame()
    {

    }

    public void PauseGame()
    {

    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
