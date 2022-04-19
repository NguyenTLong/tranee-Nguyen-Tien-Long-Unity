using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject obj;

    GameObject player;
    Vector3 cameraPositionOffset;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        cameraPositionOffset = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {

        obj.transform.position = player.transform.position + cameraPositionOffset;
    }
}
