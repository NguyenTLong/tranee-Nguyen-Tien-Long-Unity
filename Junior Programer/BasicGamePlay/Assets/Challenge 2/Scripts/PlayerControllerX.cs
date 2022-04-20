using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float timeLastPass = 0;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float time = Time.time;
            float deltaTime =  time - timeLastPass;
            if (deltaTime > 2f)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timeLastPass = time;
            }
            
        }
    }

}
