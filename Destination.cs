using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destination : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private GameObject complectLevelUI;

    [Header("AudioSetting")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private string completedAudio = "Completed";

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audioManager.Play(completedAudio);
            complectLevelUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }




}
