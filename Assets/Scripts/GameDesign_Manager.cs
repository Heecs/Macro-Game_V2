using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDesign_Manager : MonoBehaviour
{
    [SerializeField]
    private float gravityMod;

    public GameObject gameOverScreen;
    public Scene_Loader sceneLoader;
    public GameObject player;
    private void Awake()
    {
        Physics.gravity*=gravityMod;
        player.SetActive(true);
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
        player.SetActive(false);
        gameOverScreen.SetActive(false);
        sceneLoader.StartTransition();
        Time.timeScale = 1;
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
