using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    [SerializeField] float speed;
    [SerializeField] GameObject roof;

    [SerializeField] float maxPos;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float InputHorizontal = Input.GetAxis("Horizontal");

        playerRb.velocity = Vector3.forward * speed * InputHorizontal;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            roof.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            roof.SetActive(false);
        }

        if (transform.position.z > maxPos)
        {
            transform.position = Vector3.forward * maxPos;
        }
        if (transform.position.z < -maxPos)
        {
            transform.position = Vector3.forward * -maxPos;
        }
    }
}
