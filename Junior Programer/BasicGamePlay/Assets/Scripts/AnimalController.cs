using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private GameObject obj;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
