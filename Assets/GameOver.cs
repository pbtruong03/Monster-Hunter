using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    public GameManager gameManager;
    public Audiomanager audiomanager;
    public void Awake()
    {
        audiomanager = FindObjectOfType<Audiomanager>();
        gameManager = FindObjectOfType<GameManager>();
    }
    public void Home()
    {
        audiomanager.PauseMusic();
        gameOver.SetActive(false);
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1.0f;
    }
    public void HomeNResetData()
    {
        gameManager.ResetData();
        this.Home();
    }
    public void Restart()
    {
        audiomanager.PlayMusic();
        gameManager.ResetData();
        gameOver.SetActive(false);
        SceneManager.LoadSceneAsync(2);
        Time.timeScale = 1.0f;
    }
}
