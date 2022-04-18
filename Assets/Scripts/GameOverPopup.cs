using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText=null;
    [SerializeField] private TextMeshProUGUI bestScoreText = null;
    [SerializeField] private GameObject gameOverPopup = null;

    private AudioSource audioSource;

    private void OnEnable()
    {
        gameOverPopup.SetActive(false);

        audioSource = GetComponent<AudioSource>();

        GameEvents.GameOverEvent+=OnGameOverEvent;
    }

    private void OnDisable()
    {
        GameEvents.GameOverEvent-=OnGameOverEvent;
    }

    private void OnGameOverEvent()
    {
        gameOverPopup.SetActive(true);

        if(!AudioManager.Instance.IsSoundFxMuted())
            audioSource.Play();

        currentScoreText.SetText(DataSaver.ReadCurrentScoreData().ToString());
        bestScoreText.SetText(DataSaver.ReadHighestScoreData().ToString());
    }
}
