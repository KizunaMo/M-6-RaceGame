using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComplectedLevel : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private string mainMenu = "MainMenu";
    [SerializeField] private string nextLevel = "level02";
    [SerializeField] private int levelUnlock = 2;//這是需要傳到PlayerPrefs裡面的



    // Start is called before the first frame update
    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelUnlock);
        sceneFader.FadeTo(nextLevel);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        sceneFader.FadeTo(mainMenu);
        Time.timeScale = 1f;
    }

  







}
