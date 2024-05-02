using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiGameScene : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
   
    [SerializeField] private TextMeshProUGUI enemiesLefttext;

    // functions

    public void UpdateEnemiesText(int enemiesInScene, int EnemiesInWave)
    {
        enemiesLefttext.text = $"enemies: {enemiesInScene} / {EnemiesInWave}";
    }
    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
    }
    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
    }
    public void PauseGame()
    {
        ShowPausePanel();
        Time.timeScale = 0f;
    }
    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void ContinueGame()
    {
        HidePausePanel();
        Time.timeScale = 1f;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Start

    private void Start()
    {
        HideGameOverPanel();
        HidePausePanel();
        Time.timeScale = 1f;

    }
}
