using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonSelector : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private SceneFader sceneFader;



    public  Button [] levelbuttuns;



    // Start is called before the first frame update
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levelbuttuns.Length; i++)
        {
            //沒有達到levelReached就鎖住按鈕(達到的情況是數值小於levelReached)
            //(以下僅開放第一關，但通關後在其他腳本解除鎖定,更新levelReached的數值，便會改變解鎖的項目
            if (i +1 > levelReached)
            {
                levelbuttuns[i].interactable = false;
            }
        }


    }

    // Update is called once per frame

    public void Selected(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }
}
