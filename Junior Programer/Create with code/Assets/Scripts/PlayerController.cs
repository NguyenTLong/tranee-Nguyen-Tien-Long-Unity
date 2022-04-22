using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    GameObject obj;

    [SerializeField] private float hourseForce;

    [SerializeField] float moveSpeed = 10;
    [SerializeField] float turnSpeed = 10;
    [SerializeField] float speed;
    int wheelsOnGround;
    

    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI RPMText;

    [SerializeField] WheelCollider[] wheels;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && IsOnGround())
        {
            // move the car forward
            playerRb.AddRelativeForce( Vector3.forward * Time.deltaTime * hourseForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.S) && IsOnGround())
        {
            // move the car backward
            playerRb.AddRelativeForce(Vector3.back * Time.deltaTime * hourseForce,ForceMode.Impulse);
        }

        // not turning the car if it doesn't moving
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) && IsOnGround())
        {
            // turn the car to left
            if (Input.GetKey(KeyCode.A))
            {
                obj.transform.Rotate(new Vector3(0, -70 * Time.deltaTime, 0));
            }

            // turn the car to right
            if (Input.GetKey(KeyCode.D))
            {
                obj.transform.Rotate(new Vector3(0, 70 * Time.deltaTime, 0));
            }
        }

        speed = playerRb.velocity.magnitude * 3.6f;
        speedometerText.text = "Speed: " + Mathf.Round(speed) + " Km/h";

        RPMText.text = "RPM: " + wheels[0].rpm/60;
    }
    bool IsOnGround()
    {

        wheelsOnGround = 0;
        foreach (WheelCollider wheel in wheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
