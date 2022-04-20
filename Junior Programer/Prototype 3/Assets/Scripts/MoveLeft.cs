using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    GameObject obj;

    private float moveSpeed = 20;
    private float leftBound = -15;

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            obj.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }

        if (obj.transform.position.x < leftBound && obj.CompareTag("Obstacle"))
        {
            Destroy(obj);
        }
    }
}
