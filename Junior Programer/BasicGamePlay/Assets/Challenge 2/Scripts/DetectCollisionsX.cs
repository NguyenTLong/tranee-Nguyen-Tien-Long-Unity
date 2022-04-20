using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Dog")
        {
            Debug.Log("The Dog had catch the ball! -.-");
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
