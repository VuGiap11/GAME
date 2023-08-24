using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    public float jumpForce = 5.0f;
    private bool isRunning = false;
    public Animator aim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputHozirontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRunning = true;
                aim.SetBool("Run", true);
                aim.SetBool("Walk", false);
                aim.SetBool("Dle", false );
                aim.SetBool("Jump", false);
            }else
            {
                isRunning= false;
                aim.SetBool("Run", false);
                aim.SetBool("Walk", true);
                aim.SetBool("Dle", false);
                aim.SetBool("Jump", false);
            }
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            float currenSpeed = isRunning ? runSpeed : walkSpeed;
            rb.velocity = moveDirection * currenSpeed + new Vector3(0, rb.velocity.y, 0);
            if (moveDirection != Vector3.zero) 
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime);
            }
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            aim.SetBool("Run", false);
            aim.SetBool("Walk", false);
            aim.SetBool("Dle", true);
            aim.SetBool("Jump", false);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            aim.SetBool("Run", false);
            aim.SetBool("Walk", false);
            aim.SetBool("Dle", false);
            aim.SetBool("Jump", true);
        }
    }
}
