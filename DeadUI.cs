using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DeadUI : MonoBehaviour
{

    [SerializeField] private GameObject deadUI;
    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private string mainMenu = "MainMenu";


    public void MainMenu()
    {
        deadUI.SetActive(false);
        sceneFader.FadeTo(mainMenu);
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        deadUI.SetActive(false);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);//重新讀取當前的場景
        Time.timeScale = 1f;
    }
}
