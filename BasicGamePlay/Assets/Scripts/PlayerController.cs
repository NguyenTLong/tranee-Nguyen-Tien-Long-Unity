using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject obj;



    private float horizontalInput;

    public GameObject food;
    public float moveSpeed = 15;
    public float xRange = 15;

    private Vector3 foodOffset = new Vector3(0,2,1);

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // get input value
        horizontalInput = Input.GetAxis("Horizontal");


        // move the player by input value
        obj.transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * moveSpeed);


        /// check if the obj move out of gameplay limit
        // for the right part
        if (obj.transform.position.x > xRange)
        {
            obj.transform.position = new Vector3(xRange, obj.transform.position.y,obj.transform.position.z);
        }
        // for the left part
        if (obj.transform.position.x < -xRange)
        {
            obj.transform.position = new Vector3(-xRange, obj.transform.position.y, obj.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(food, obj.transform.position + foodOffset, Quaternion.identity);
        }
    }
}
