using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.LowLevel;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public SaveSystem saveSystem;
    private Audiomanager audiomanager;

    [SerializeField] _DataTeleportPosition backtoMap1;
    [SerializeField] _DataTeleportPosition gotoMap2;
    [SerializeField] _DataTeleportPosition backtoMap2;
    [SerializeField] _DataTeleportPosition gotoMap3;
    private void Awake()
    {
        SceneManager.sceneLoaded += Initialize;
        audiomanager = FindAnyObjectByType<Audiomanager>();
    }
    private void Initialize(Scene scene, LoadSceneMode sceneMode)
    {
        var playerInput = FindObjectOfType<PlayerController>();
        if (playerInput != null)
            player = playerInput.gameObject;
        saveSystem = FindObjectOfType<SaveSystem>();
        if (player != null && saveSystem.LoadedData != null && saveSystem.LoadData())
        {
            // Lay du lieu nhan vat
            float _health = saveSystem.LoadedData.PlayerHealth;
            float _px = saveSystem.LoadedData.PlayerPositionX;
            float _py = saveSystem.LoadedData.PlayerPositionY;
            float _score = saveSystem.LoadedData.score;
            // Cai dat du lieu nhan vat
            playerInput.setScore(_score);
            playerInput.setHealth(_health);
            playerInput.setPosition(_px, _py);
        }
    }

    public void loadContinue()
    {
        if (saveSystem.LoadedData != null)
        {
            SceneManager.LoadScene(saveSystem.LoadedData.SceneIndex);
            return;
        }
        LoadNextMap();
    }
    public void newGame()
    {
        audiomanager.PlayMusic();
        saveSystem.ResetData();
        SceneManager.LoadScene(2);
    }
    public void LoadPrevMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void LoadNextMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SaveData()
    {
        if (player != null)
        {
            PlayerController player_ctler = player.GetComponent<PlayerController>();
            float score = player_ctler.getScore();
            float player_health = player_ctler.getHealth();
            float positionX = player_ctler.getPositionX();
            float positionY = player_ctler.getPositionY();
            saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex,score, player_health, positionX, positionY);
        }
    }
    public void SaveData(int prevScene, int curScene)
    {
        audiomanager.TeleportSFX();
        if (player != null)
        {
            PlayerController player_ctler = player.GetComponent<PlayerController>();
            float player_health = player_ctler.getHealth();
            float positionX, positionY;
            float score = player_ctler.getScore();
            if(prevScene == 4)
            { // Go to Map 2 from Map 3
                positionX = backtoMap2.X;
                positionY = backtoMap2.Y;
            } else if (prevScene ==3  && curScene == 2){
                // Go to map 1 from Map 2
                positionX = backtoMap1.X; positionY = backtoMap1.Y;
            } else if (prevScene == 2 && curScene == 3)
            {   // Go to Map 2 from Map 1
                positionX = gotoMap2.X; positionY = gotoMap2.Y;
            } else
            {   // Go to Map 3 from Map 3
                positionX = gotoMap3.X; positionY = gotoMap3.Y;
            }
            saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex,score, player_health, positionX, positionY);
        }
    }

    public void ResetData()
    {
        saveSystem.ResetData();
    }

    // Audio Manager
    public void clickButtonSFX()
    {
        audiomanager.ClickbuttonSFX();
    }
    public void PlayMusic()
    {
        audiomanager.PlayMusic();
    }
    public void PauseMusic()
    {
        audiomanager.PauseMusic();
    }
    public void UnPauseMusic()
    {
        audiomanager.UnPauseMusic();
    }
}
