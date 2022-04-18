using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private bool muteBackgroundMusic = false;
    private bool muteSoundFx = false;

    private AudioSource audioSource;
    public static AudioManager Instance { get; set; }

    private void Awake()
    {
        // Singleton Implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Destroy(this);
        }
    }

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        GameEvents.GameOverEvent+=OnGameOver;
        SceneManager.sceneLoaded+=SceneManagerOnSceneLoaded;
    }

    private void OnDisable()
    {
        GameEvents.GameOverEvent-=OnGameOver;
        SceneManager.sceneLoaded-=SceneManagerOnSceneLoaded;
    }

    private void SceneManagerOnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        audioSource.Play();
    }
    private void OnGameOver()
    {
        audioSource.Stop();
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void ToggleBackgroundMusic(){

        muteBackgroundMusic = !muteBackgroundMusic;

        if (muteBackgroundMusic) audioSource.Stop();
        else                     audioSource.Play();
    }

    public void ToggleSoundFx()
    {
        muteSoundFx = !muteSoundFx;
    }

    public bool IsBackgroundMusicMuted()
    {
        return muteBackgroundMusic;
    }

    public bool IsSoundFxMuted()
    {
        return muteSoundFx;
    }

    public void SilenceBackgroundMusic(bool silence)
    {
        if (muteBackgroundMusic == false)
        {
            audioSource.volume = (silence) ? 0f : 1f;
        }
    }
}// Class
