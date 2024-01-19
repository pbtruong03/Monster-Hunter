using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrevMap : MonoBehaviour
{
    public GameManager gameManager;
    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            int curSceneIndex = SceneManager.GetActiveScene().buildIndex;
            gameManager.SaveData(curSceneIndex, curSceneIndex - 1);
            gameManager.LoadPrevMap();
        }
    }
}
