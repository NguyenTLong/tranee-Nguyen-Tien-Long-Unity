using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private GameObject focalPoint;
    public GameObject powerupIndicator;

    public float speed = 5.0f;
    private bool hasPowerUp;
    private float powerUpstrength = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        powerupIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    private async void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Player collided with " + collision.gameObject.name + " with power up set to " + hasPowerUp);
            enemyRb.AddForce(awayFromPlayer * powerUpstrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(1);

            if (i == 6)
            {
                hasPowerUp = false;
                powerupIndicator.gameObject.SetActive(false);
            }

            if (i <= 6)
            {
                Debug.Log("Power Up count down: " + (7 - (i + 1)));
            }

            if (i == 7)
            {
                Debug.Log("Power Up End!!! ");
            }
            
        }

        
       
    }
}
