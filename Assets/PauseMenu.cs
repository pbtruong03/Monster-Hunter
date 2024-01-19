using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public GameManager gameManager;
    public Audiomanager audiomanager;
    public void Awake()
    {
        audiomanager = FindObjectOfType<Audiomanager>();
        gameManager = FindObjectOfType<GameManager>();
    }
    public void Pause()
    {
        
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Home()
    {
        audiomanager.PauseMusic();
        pauseMenu.SetActive(false);
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1.0f;
    }
    public void HomeNResetData()
    {
        gameManager.ResetData();
        this.Home();
    }
    public void HomeNSaveData()
    {
        gameManager.SaveData();
        this.Home();
    }
    public void Restart()
    {
        gameManager.ResetData();
        pauseMenu.SetActive(false);
        SceneManager.LoadSceneAsync(2);
        Time.timeScale = 1.0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
