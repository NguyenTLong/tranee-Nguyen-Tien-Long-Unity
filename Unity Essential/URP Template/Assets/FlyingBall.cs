using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBall : MonoBehaviour
{
    GameObject obj;
    public Vector3 startPosittion;
    public float moveSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        startPosittion = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(obj.transform.position.z - startPosittion.z) >= 2)
        {
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y,startPosittion.z + 2 * (moveSpeed > 0 ? 1 : -1));
            moveSpeed *= -1;
        }
        obj.transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime );
        
    }
}
