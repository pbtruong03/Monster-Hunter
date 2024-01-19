using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject continueBtn;
    public void Start()
    {
        if(continueBtn != null)
            setContinueBtn();
    }
    public void setContinueBtn()
    {
        if (PlayerPrefs.HasKey("SavePresent"))
        {
            continueBtn.SetActive(true);
        }
        else continueBtn.SetActive(false);
    }
    //Play game
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
