using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private GameObject obj;
    public float topBound = 30;
    public float lowerBound = -10;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.transform.position.z > topBound)
        {
            Destroy(obj);
        } else if (obj.transform.position.z < lowerBound)
        {
            Destroy(obj);
            Debug.Log("Game Over !! -.- ");
            Time.timeScale = 0;
        }
    }
}
