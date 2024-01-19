using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    [Header("---Audio Source---")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource SFX1Source;

    [Header("---Audio Clip---")]
    public AudioClip background;
    public AudioClip swoodhit;
    public AudioClip running;
    public AudioClip clickButton;
    public AudioClip gameOver;
    public AudioClip teleportSFX;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        MusicSource.clip = background;
    }

    // Music Background
    public void PlayMusic()
    {
        MusicSource.Pause();
        MusicSource.Play();
    }
    public void PauseMusic()
    {
        MusicSource.Pause();
    }
    public void UnPauseMusic()
    {
        MusicSource.UnPause();
    }

    // SFX Audio
    public void ClickbuttonSFX()
    {
        SFXSource.clip = clickButton;
        SFXSource.Play();
    }
    public void PlayerRunSFX()
    {
        SFXSource.clip = running;
        SFXSource.Play();
    }

    public void PlayerAtkSFX()
    {
        SFX1Source.clip = swoodhit;
        SFX1Source.Play();
    }
    public void TeleportSFX()
    {
        SFX1Source.clip = teleportSFX;
        SFX1Source.Play();
    }
    public void KillEnemySFX()
    {

    }
    public void GameOverMusic()
    {
        MusicSource.Stop();
        SFX1Source.clip = gameOver;
        SFX1Source.Play();
    }
}
