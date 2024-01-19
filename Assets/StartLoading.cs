using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLoading : MonoBehaviour
{
    [SerializeField] private Image loadingfill;
    [SerializeField] AudioMixer myMixer;

    private float loadingFloat;
    private void Start()
    {
        loadingFloat = 0f;
        // Set volume 
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            float volume = PlayerPrefs.GetFloat("musicVolume");
            myMixer.SetFloat("music", volume);
        }
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            float volume = PlayerPrefs.GetFloat("sfxVolume");
            myMixer.SetFloat("sfx", volume);
        }
    }
    private void Update()
    {
        loadingFloat += Time.deltaTime;
        loadingfill.fillAmount = loadingFloat;
        if (loadingFloat >= 1f)
        {
            SceneManager.LoadSceneAsync(1);
        }
    }
}
