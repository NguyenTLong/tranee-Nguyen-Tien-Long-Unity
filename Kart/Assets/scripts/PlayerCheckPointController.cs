using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPointController : MonoBehaviour
{
    Vector3 lastCheckPoint;
    Vector3 lastRolation;

    public FadeInFadeOut fade;

    [SerializeField]
    private bool useRToRespawn;

    private bool isRespawning = false;

    // Start is called before the first frame update
    void Start()
    {
        lastCheckPoint = gameObject.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && useRToRespawn)
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
            other.GetComponent<turnOffTIme>().turnOffInAmountOfTime(5);
        }

        if (other.CompareTag("ResetArea") && !isRespawning)
        {
            Debug.Log("into reset area");
            fade.fadeIn = true;
            isRespawning = true;
            StartCoroutine(setDistance(2));
        }
    }

    IEnumerator setDistance(int time)
    {
        yield return new WaitForSeconds(time);
        fade.panel.alpha = 1;
        fade.fadeOut = true;
        gameObject.transform.position = lastCheckPoint;
        gameObject.transform.eulerAngles = lastRolation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;


        isRespawning = false;
    }
}
