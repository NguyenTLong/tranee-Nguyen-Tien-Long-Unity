using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPointController : MonoBehaviour
{
    Vector3 lastCheckPoint;
    Vector3 lastRolation;
    // Start is called before the first frame update
    void Start()
    {
        lastCheckPoint = gameObject.transform.position;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(setDistance(0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            lastCheckPoint = other.gameObject.transform.position;
            lastRolation = other.gameObject.transform.eulerAngles;
        }
        if (other.CompareTag("ResetArea"))
        {
            StartCoroutine(setDistance(2));
        }
    }

    IEnumerator setDistance(int time)
    {
        yield return new WaitForSeconds(time);
        gameObject.transform.position = lastCheckPoint;
        gameObject.transform.eulerAngles = lastRolation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        
    }
}
