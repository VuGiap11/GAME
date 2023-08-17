using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{

    //public float moveSpeed = 10f;
    //public float maxSpeed = 20f;
    //private Rigidbody rb;
    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}
    //private void Update()
    //{
    //    float hozirontalMove = Input.GetAxis("Horizontal");
    //    float verticalMove = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(hozirontalMove, 0f, verticalMove) * moveSpeed * Time.deltaTime;

    //    transform.Translate(movement);
    //    rb.AddForce(movement * moveSpeed);

    //    if (rb.velocity.magnitude > maxSpeed)
    //    {
    //        rb.velocity = rb.velocity.normalized * maxSpeed;
    //    }
    //}
    [SerializeField] private WheelCollider frontLeftWheel;
    [SerializeField] private WheelCollider frontRightWheel;
    [SerializeField] private WheelCollider rearLeftWheel;
    [SerializeField] private WheelCollider rearRightWheel;
    [SerializeField] private float maxStreerAngle = 30f;
    [SerializeField] private float motorForce = 1500f;

    [SerializeField] private float brakeForce = 3000f;
    private Rigidbody rb;
    private int damaged = 0;
    private float fuel = 100f;
    private float capacity = 100f;

    private int laps = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        float steerAngle = maxStreerAngle * inputHorizontal;

        float force = motorForce * inputVertical;

        frontLeftWheel.steerAngle = steerAngle;
        frontRightWheel.steerAngle = steerAngle;

        rearLeftWheel.motorTorque = force;
        rearRightWheel.motorTorque = force;

        if (Input.GetKey(KeyCode.Space)) 
        {
            frontLeftWheel.brakeTorque = brakeForce;
            frontRightWheel.brakeTorque = brakeForce;
            rearLeftWheel.brakeTorque = brakeForce;
            rearRightWheel.brakeTorque = brakeForce;
        }else
        {
            frontLeftWheel.brakeTorque = 0f;
            frontRightWheel.brakeTorque = 0f;
            rearLeftWheel.brakeTorque = 0f;
            rearRightWheel.brakeTorque = 0f;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Car"))
        {
            rb.velocity = Vector3.zero;
            damaged += 5;
            if (damaged >= 100)
            {
                ResetSence();
            }
        }

        if (collision.gameObject.CompareTag("Lap"))
        {
            laps += 1;
        }
    }
    public void ResetSence()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
