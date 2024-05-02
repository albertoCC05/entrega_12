using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class DataPersistance : MonoBehaviour
{
    // player prefs

    private const string POINTS = "Points";
    public int puntuation;

    private const string DIFILCUTY = "Dificulty";
    public int dificulty = 0;  

    // if dificulty equals 0 it means that you are playing on normal mode
    // if dificulty mode equals 1 it means that you are playing on hard moode an power ups will not spawn

    // scripts reference

    private PlayerController playerController;
    private UImanager uImanager;
    

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        uImanager = FindObjectOfType<UImanager>();
        

        
    }


    // for the first data to save, i will save the last player puntuation, and in main menu i will show in a panel the last puntuation 
    // I will save the points every time that you get one point ( when a enemy dies ) and i will load it on the menu on clic the button to check the puntuation
    // i will save this information with playerPrefs


    private const string JSON_DIFICULTY_SAVEFILE = "/save_dificulty";


    // for the econd data, I will save a bool that sayis if you are playing on hardmode or not, this variable will be true if you play on hard and power ups will not apear and false if you play normal
    // i will save the value when you click in one of the two buttons for play and y will load the value on start the game scene

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

    // dificulty save and load 


    public void SaveDificulty()
    {
        int isHardMode = dificulty;

        PlayerPrefs.SetInt(DIFILCUTY, isHardMode);


       

    }
    public void LoadDificulty()
    {
        if (PlayerPrefs.HasKey (DIFILCUTY))
        {
            int dificlty = PlayerPrefs.GetInt(DIFILCUTY);
            dificulty = dificlty;

        }
        else
        {
            
            Debug.LogError("there is no dificulty saved");

        }
    }

    public void SetNormalMode()
    {
        dificulty = 0;
    }
    public void SetHardMode()
    {
        dificulty = 1;
    }




}
