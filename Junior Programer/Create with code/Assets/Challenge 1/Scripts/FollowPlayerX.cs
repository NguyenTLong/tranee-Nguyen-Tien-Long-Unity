using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    private GameObject obj;

    public GameObject plane;

    private Vector3 cameraPositionOffset;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        cameraPositionOffset = obj.transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = plane.transform.position + cameraPositionOffset;
    }
}
