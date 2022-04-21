using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = 5.5f;

    private float zDestroy = -10f;
    private Rigidbody objRb;
    // Start is called before the first frame update
    void Start()
    {
        objRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objRb.AddForce(Vector3.forward * -speed);

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }
}
