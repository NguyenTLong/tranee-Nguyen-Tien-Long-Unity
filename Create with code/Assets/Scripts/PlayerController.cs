using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject obj;

    public float moveSpeed = 10;
    public float turnSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // move the car forward
            obj.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            // move the car backward
            obj.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }

        // not turning the car if it doesn't moving
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
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
    }
}
