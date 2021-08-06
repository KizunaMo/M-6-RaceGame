using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;


    public static GameManager instance;


    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueButton()
    {
        Debug.Log("Game Continue");

    }

    public void MainMenuButton()
    {
        Debug.Log("Go to Main Menu");
        SceneManager.LoadScene("MainMenu");

    }


    public void QuitButton()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }





}
