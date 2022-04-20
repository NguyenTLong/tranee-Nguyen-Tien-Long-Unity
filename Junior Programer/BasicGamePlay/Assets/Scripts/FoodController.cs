using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    GameObject obj;

    public GameObject child;

    public float speed;
    public float rolateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(Vector3.forward * Time.deltaTime * speed);

        child.transform.Rotate(Vector3.up * rolateSpeed);

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(obj);
        Destroy(other.gameObject);
    }
}
