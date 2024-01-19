using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class SaveSystem : MonoBehaviour
{
    public string playerHealthKey = "PlayerHealth",
                scoreKey = "score",
                sceneKey = "SceneIndex",
                playerPositionXkey = "PlayerPositionX",
                playerPositionYkey = "PlayerPositionY",
                savePresentKey = "SavePresent";
    public LoadedData LoadedData { get ; private set; }
    public UnityEvent<bool> OnDataLoadedResult;
    private bool IsInitializes = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        if (IsInitializes) {
            return;
        }
        var result = LoadData();
        OnDataLoadedResult?.Invoke(result);
        IsInitializes = true;
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteKey(scoreKey);
        PlayerPrefs.DeleteKey(playerHealthKey);
        PlayerPrefs.DeleteKey(sceneKey);
        PlayerPrefs.DeleteKey(savePresentKey);
        PlayerPrefs.DeleteKey(playerPositionXkey);
        PlayerPrefs.DeleteKey(playerPositionYkey);
        LoadedData = null;
    }
    public bool LoadData()
    {
        if(PlayerPrefs.GetInt(savePresentKey) == 1)
        {
            LoadedData = new LoadedData();
            LoadedData.score = PlayerPrefs.GetFloat(scoreKey);
            LoadedData.PlayerHealth = PlayerPrefs.GetFloat(playerHealthKey);
            LoadedData.SceneIndex = PlayerPrefs.GetInt(sceneKey);
            LoadedData.PlayerPositionX = PlayerPrefs.GetFloat(playerPositionXkey);
            LoadedData.PlayerPositionY = PlayerPrefs.GetFloat(playerPositionYkey);
            return true;
        }
        return false;
    }
    public void SaveData(int sceneIndex, float score, float playerHealth, float positionX, float positionY)
    {
        if(LoadedData == null)
        {
            LoadedData = new LoadedData();
        }
        LoadedData.PlayerHealth = playerHealth;
        LoadedData.SceneIndex = sceneIndex;
        LoadedData.PlayerPositionX = positionX;
        LoadedData.PlayerPositionY = positionY;

        PlayerPrefs.SetFloat(scoreKey, score);
        PlayerPrefs.SetFloat(playerHealthKey, playerHealth);
        PlayerPrefs.SetInt(sceneKey, sceneIndex); 
        PlayerPrefs.SetFloat(playerPositionXkey, positionX);
        PlayerPrefs.SetFloat(playerPositionYkey, positionY);
        PlayerPrefs.SetInt(savePresentKey, 1);
    }
}

public class LoadedData
{
    public float score = 0;
    public float PlayerHealth = -1;
    public int SceneIndex = -1;
    public float PlayerPositionX = 0;
    public float PlayerPositionY = 0;
}
