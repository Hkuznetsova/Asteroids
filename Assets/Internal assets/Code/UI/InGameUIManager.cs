using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] RectTransform pausePanel;
    [SerializeField] RectTransform gameOverPanel;

    [SerializeField] Button gameOverExitButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button inPauseExitButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button resumeBackgroundButton;
    [SerializeField] Button pauseButton;

    [SerializeField] Slider healthSlider;

    [SerializeField] Text scoreText;
    [SerializeField] Text scoreGameOverText;

    [HideInInspector]
    public static InGameUIManager Instance;

    private bool pauseGameFlag;
    private int score;

    private void Awake()
    {
        Instance = this;
        inPauseExitButton.onClick.AddListener(OnExitButtonClick);
        resumeButton.onClick.AddListener(OnResumeButtonClick);
        pauseButton.onClick.AddListener(OnPauseButtonClick);
        resumeBackgroundButton.onClick.AddListener(OnResumeButtonClick);
        gameOverExitButton.onClick.AddListener(OnExitButtonClick);
        restartButton.onClick.AddListener(OnRestartButtonClick);

        pausePanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);

        SetHealthSliderValue(1);
        score = 0;
        SetScoreValue(0);
        pauseGameFlag = false;
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene("GameScene"); 
    }

    private void OnPauseButtonClick()
    {
        if (!pauseGameFlag)
        {
            pausePanel.gameObject.SetActive(true);
            Time.timeScale = 0;
            pauseGameFlag = !pauseGameFlag;
        }
        
    }

    private void OnResumeButtonClick()
    {
        if (pauseGameFlag)
        {
            pausePanel.gameObject.SetActive(false);
            Time.timeScale = 1;
            pauseGameFlag = !pauseGameFlag;
        }
    }

    private void OnExitButtonClick()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void SetHealthSliderValue(float value)
    {
        healthSlider.value = value;
    }
    public void GameOver()
    {
        scoreGameOverText.text = "YOU SCORE: " + score.ToString();
        gameOverPanel.gameObject.SetActive(true);

    }
    public void SetScoreValue(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}