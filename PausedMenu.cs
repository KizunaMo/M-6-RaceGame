using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private GameObject ui;
    [SerializeField] private string mainMenu = "MainMenu";


        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);//讓自身成為相反狀態；更進一步說明，目前設定unity內部的這個ui是false，所以!ui.activeSelf會把狀態變成true;
        

        if (ui.activeSelf)//ui.activeSelf就又返回成true狀態
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void retry()
    {

    }

    public void MainMenu()
    {
        Toggle();
        sceneFader.FadeTo(mainMenu);
    }





}
