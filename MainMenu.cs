using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("SceneLoad")]
    public string loadLoadMenu = "LoadMenu";
    public string loadMainMenu = "MainMenu";
    public string loadLevel01 = "Level01";


    [Header("Setting")]
    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private GameObject confirmPanel;




    public void LoadToLoadMenu()
    {
        sceneFader.FadeTo(loadLoadMenu);
    }

    public void LoadToMainMenu()
    {

        sceneFader.FadeTo(loadMainMenu);
    }

    public void StartNewGame()
    {
        Debug.Log("Start a new game.");
        //出現確認是否刪除遊戲資訊視窗
        confirmPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Exit ");
        Application.Quit();
    }


    //summy NewGameConfirm
    public void DeleteGameData()
    {
        Debug.Log("刪除遊戲資訊");
        PlayerPrefs.DeleteAll();//刪除所有資訊
        confirmPanel.SetActive(false);
        sceneFader.FadeTo(loadLevel01);
    }

    public void CancelButton()
    {
        confirmPanel.SetActive(false);
        LoadToMainMenu();
    }
   
}
