using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaittingTime : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private float countdown = 3f;
    [SerializeField] private Text waittingTimeText;
    [SerializeField] GameObject player;

    private void Start()
    {
        PlayerStopped();
    }

    // Update is called once per frame
    void Update()
    { 
        //waittingTime
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waittingTimeText.text = countdown.ToString("0");
        if (countdown <= 0f)
        {
            waittingTimeText.text = null;
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            return;
        }
    }

   /// <summary>
   /// 先讓玩家停止動作(玩家腳本暫停)
   /// </summary>
    private void PlayerStopped()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled =false;
    }
}
