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
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float turnSmoothVelocity;

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
            
            rb.AddForce(-turnSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            //第三人稱轉向(Y軸)
            float targetAngle = Mathf.Atan2(rb.transform.position.x, rb.transform.position.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity , turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);



        }
        if (turnRight)
        {
            rb.AddForce(turnSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

           
            float targetAngle = Mathf.Atan2(rb.transform.position.x, rb.transform.position.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


        }
    }


}
