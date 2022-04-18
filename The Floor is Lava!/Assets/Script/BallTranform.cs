using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTranform : MonoBehaviour
{
    public Vector3 valueChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += valueChange * Time.deltaTime;
        transform.position += valueChange * Time.deltaTime;
        transform.Rotate(valueChange * Time.deltaTime);
    }
}
