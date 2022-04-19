using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerController : MonoBehaviour
{
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        obj.gameObject.transform.Rotate(new Vector3(0, 0, 1));
    }
}
