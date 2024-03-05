using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [Header("Plane Stats")]
    [Tooltip("How much the throttle ramps up or down.")]
    public float throttleIncrement = 0.1f;
    [Tooltip("Maximum Engine thrust when at 100% throttle")]
    public float maxThrust = 200f;
    [Tooltip("How responsive the plane is when rolling, pitching and yawing.")]
    public float responsiveness = 10f;

    private float throttle;
    private float roll;
    private float yaw;
    private float pitch;

    public GameObject pervane1;
    public GameObject pervane2;

    public float rotationSpeed = 1000f; // Hýz 2 katýna çýkarýldý
    private float responseModifier
    {
        get
        {
            return (rb.mass / 10f)*responsiveness ;
        }
    }

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void HandleInputs () 
    {
        roll = Input.GetAxis("Vertical");
        pitch = Input.GetAxis("Horizontal");
        yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0, 100f);
    }

    private void Update () 
    {
    HandleInputs();

        if (Input.GetKey(KeyCode.Space))
        {

            pervane1.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
            pervane2.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);



        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.right * maxThrust * throttle*-1);
        rb.AddTorque(transform.up* yaw* responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(transform.forward * roll * responseModifier);
    }



}
