using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AMOCover : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private string mainMenu = "MainMenu";



    // Start is called before the first frame update
    void Start()
    {
        Invoke("MainMenu", 3f);
    }


    void MainMenu()
    {

        sceneFader.FadeTo(mainMenu);
    }
 
}
