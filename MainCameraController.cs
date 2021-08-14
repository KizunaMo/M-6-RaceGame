using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{

    [Header("Setting")]
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 deadOffset;
    [SerializeField] private Vector3 playerPosition;

    private Rigidbody rb;
    private float moveSpeed = 30f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerMovement.playerDead = false;
    }
    // Update is called once per frame
    void Update()
    {
        playerPosition = player.position;

        if (PlayerMovement.playerDead)
        {
            transform.position = player.position + deadOffset;
            transform.rotation = Quaternion.Euler(10.06f, -1.02f, -8.37f);
        }
        else
        {
            
            transform.position = player.position + offset;
        }
        
    }





}
