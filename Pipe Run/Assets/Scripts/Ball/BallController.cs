using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    #region Variable



    #endregion
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PipeMesh"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 3, 0);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EndGame();
        }
    }
}
