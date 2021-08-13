using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaittingTime : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private float countdown = 3f;
    [SerializeField] private Text waittingTimeText;
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private Animator animatorDialougueUI;
    [SerializeField] private Animator animatorCountDown;

    [SerializeField] private Dialogue dialogue;

    private bool dialogueBox = true;

    private void Start()
    {
        if (dialogueBox)
        {
            dialogueUI.SetActive(true);
            dialogueBox = true;
        }
        

        if (dialogueBox)
        {
            animatorDialougueUI.SetBool("isOpen", true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }


        PlayerStopped();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!dialogueBox) 
        {
            isCount();
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
        
    }

   /// <summary>
   /// 先讓玩家停止動作(玩家腳本暫停)
   /// </summary>
    private void PlayerStopped()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled =false;
    }

    public void CloseDialogueUI()
    {
        dialogueUI.SetActive(false);
        dialogueBox = false;
    }

    /// <summary>
    /// 倒數計時動畫
    /// </summary>
    public void isCount()
    {
        animatorCountDown.SetBool("isCount", true);
    }
   
}
