using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using Unity.VisualScripting;

public class DataPersistance : MonoBehaviour
{
    // player prefs

    private const string POINTS = "Points";
    public int puntuation;

    // for the first data to save, i will save the last player puntuation, and in main menu i will show in a panel the last puntuation 
    // I will save the points every time that you get one point ( when a enemy dies ) and i will load it on the menu on clic the button to check the puntuation
    // i will save this information with playerPrefs



    //JSON

    private const string JSON_DIFICULTY_SAVEFILE = "/save_dificulty";
    public bool hardModeActivated = false;


    // for the second data, I will save a bool that sayis if you are playing on hardmode or not, this variable will be true if you play on hard and power ups will not apear and false if you play normal
    // i will save the value when you click in one of the two buttons for play and y will load the value on start the game scene

    // scripts reference

    private PlayerController playerController;
    private UImanager uImanager;
    

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        uImanager = FindObjectOfType<UImanager>();
        

        
    }


   


   



    // enemies defeated save and load (PlayerPrefs)

    public void Save ()
    {
        int points = playerController.points;
        PlayerPrefs.SetInt(POINTS, points);


    }
    public void Load()
    {
        if (PlayerPrefs.HasKey(POINTS))
        {
            int point = PlayerPrefs.GetInt(POINTS);
            puntuation = point;
        }
        else
        {
            puntuation = 0;
            Debug.LogError("there is no puntuation");

        }
    }

    // dificulty save and load with JSON


    public void SaveDificulty()
    {
        bool dificult = hardModeActivated;

        SaveObject dificultyMode = new SaveObject()
        {
            hardMode = dificult
        };

        string jsonContent = JsonUtility.ToJson(dificultyMode);

        System.IO.File.WriteAllText(Application.dataPath + JSON_DIFICULTY_SAVEFILE, jsonContent);




    }
    public void LoadDificulty()
    {
        if (System.IO.File.Exists(Application.dataPath + JSON_DIFICULTY_SAVEFILE))
        {
            string jsonContent = System.IO.File.ReadAllText(Application.dataPath + JSON_DIFICULTY_SAVEFILE);

            SaveObject dificultyMode = JsonUtility.FromJson<SaveObject>(jsonContent);

            hardModeActivated = dificultyMode.hardMode;

            

        }
        
            
        
    }

    public void SetNormalMode()
    {
        
        hardModeActivated = false;
    }
    public void SetHardMode()
    {
        
        hardModeActivated = true;
    }




}
