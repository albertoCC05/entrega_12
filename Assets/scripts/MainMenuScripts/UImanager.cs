
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class UImanager : MonoBehaviour
{

    // variables
  
    [SerializeField] private GameObject optionsPanel;
    

    [SerializeField] private Slider musicSlider;
    [SerializeField] private AudioSource cameraAudiosource;
    [SerializeField] private TMP_Dropdown languageDropdown;

    [SerializeField] private TextMeshProUGUI playButtonText;
    [SerializeField] private TextMeshProUGUI otionsButtonText;
    [SerializeField] private TextMeshProUGUI exitButtonText;
    [SerializeField] private TextMeshProUGUI backButtonText;
    [SerializeField] private TextMeshProUGUI languageNearDropdownText;
    [SerializeField] private TextMeshProUGUI musicSliderText;
    [SerializeField] private TextMeshProUGUI optionsTitleText;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject pointsPanel;

    private DataPersistance dataPersistance;

    




    // functions



    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void HideOptionsPanel()
    {
        optionsPanel.SetActive(false);
    }
    public void ShowOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ChangeVolume()
    {
        cameraAudiosource.volume = musicSlider.value;
    }
    public void CloseGame()
    {
        Application.Quit();

    }
    private void ChangeToSpanish()
    {
        playButtonText.text = "Jugar";
        otionsButtonText.text = "Opciones";
        optionsTitleText.text = "Opciones";
        exitButtonText.text = "Salir";
        backButtonText.text = "volver";
        musicSliderText.text = "Volumen";
        languageNearDropdownText.text = "Idioma";

    }
    private void ChangeToEnglish()
    {
        playButtonText.text = "Play";
        otionsButtonText.text = "Options";
        optionsTitleText.text = "Options";
        exitButtonText.text = "Exit";
        backButtonText.text = "Back";
        musicSliderText.text = "Volume";
        languageNearDropdownText.text = "Language";
    }
    public void ChangeLanguage()
    {
        if (languageDropdown.value == 0)
        {
            ChangeToEnglish();
        }
        if (languageDropdown.value == 1)
        {
            ChangeToSpanish();
        }

    }
   public void HidePointsPanel()
    {
        pointsPanel.SetActive(false);
    }
    public void ShowPointsPanel()
    {
        pointsPanel.SetActive(true);
    }
    public void UpdateScoreText()
    {
        dataPersistance.Load();
        Debug.Log(dataPersistance.puntuation);
        scoreText.text = ($"Your last score was: {dataPersistance.puntuation}");
    }
 

    // events

    private void Start()
    {
        dataPersistance = FindObjectOfType<DataPersistance>();

        Time.timeScale = 1;
        HideOptionsPanel();
        HidePointsPanel();
        Screen.SetResolution( 1920,  1080 , false);
    }

}
