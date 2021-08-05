using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float forwardForce = 100f;



    [Header("Player Control")]
    [SerializeField] private bool turnLeft;
    [SerializeField] private bool turnRight;
    [SerializeField] private float turnSpeed = 100f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            turnLeft = true;
        if (Input.GetKeyUp(KeyCode.A))
            turnLeft = false;
      
        if (Input.GetKeyDown(KeyCode.D))
            turnRight = true;
        if (Input.GetKeyUp(KeyCode.D))
            turnRight = false;
    }


    private void FixedUpdate()
    {
        

        Movement();


    }

    public void Movement()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.Force);
        if (turnLeft)
        {
            rb.AddForce(turnSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (turnRight)
        {
            rb.AddForce(-turnSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }


}
