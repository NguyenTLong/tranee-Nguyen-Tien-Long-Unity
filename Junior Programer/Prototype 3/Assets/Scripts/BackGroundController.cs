using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    GameObject obj;
    private Vector3 startPos;
    private float repeatWidth;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        startPos = obj.transform.position;
        repeatWidth = obj.GetComponent<BoxCollider>().size.x / 2;
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            if (obj.transform.position.x < startPos.x - repeatWidth)
            {
                obj.transform.position = startPos;
            }
        }
    }
}
