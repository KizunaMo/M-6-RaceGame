using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider coll;

    [Header("Setting")]
    [SerializeField] private GameObject deadEffect;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private string playerDeadAudio = "PlayerDead";


    [Header("Player Control")]
    [SerializeField] private float forwardForce = 100f;
    [SerializeField] private bool turnLeft;
    [SerializeField] private bool turnRight;
    [SerializeField] private float turnSpeed = 100f;
    [SerializeField] private float turnSmoothVelocity;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform leftRotation;
    [SerializeField] private Transform rightRotation;
    [SerializeField] private Transform partToRotation;

    [Header("Status")]
    public static bool playerDead;


    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<BoxCollider>();
        playerDead = false;
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

        //float horizaontalInput = Input.GetAxisRaw("Horizontal");
        //Vector3 movementDirection = new Vector3(horizaontalInput, 0, 0);
        //movementDirection.Normalize();
        //if (movementDirection != Vector3.zero && yRotation < 45f && yRotation > 314f)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            
        //    //transform.rotation = Quaternion.Euler(0, yRotation, 0);
        //}
        if (turnLeft && !playerDead)
        {
            rb.AddForce(-turnSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            
            Vector3 dir = leftRotation.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotation.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
            partToRotation.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            Debug.Log(rotation.y);

        }
        if (turnRight && !playerDead)
        {
            rb.AddForce(turnSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);


            Vector3 dir = rightRotation.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotation.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
            partToRotation.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            Debug.Log(rotation.y);

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            audioManager.Play(playerDeadAudio);
            Debug.Log(collision.collider.gameObject.layer);
            Die();
        }
    }

    public void Die()
    {
        playerDead = true;
        rb.AddForce(new Vector3(0f, 30f, 0f), ForceMode.Impulse);
        GameObject effectIn = (GameObject)Instantiate(deadEffect, transform.position, Quaternion.identity);
        forwardForce = 0f;
    }
}


    
   


