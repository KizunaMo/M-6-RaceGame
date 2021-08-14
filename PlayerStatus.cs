using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private GameObject deadUI;


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Invoke("PlayerDead", 2f);
        }
    }

    public void PlayerDead()
    {
        deadUI.SetActive(true);
    }







}
