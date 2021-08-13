using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destination : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private GameObject complectLevelUI;
    [SerializeField] private GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            complectLevelUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }




}
