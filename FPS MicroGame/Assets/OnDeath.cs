using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnDeath : MonoBehaviour
{
    [SerializeField]
    private rolating droneRolate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        droneRolate.enabled = false;
        GameObject[] miniDronesList = GameObject.FindGameObjectsWithTag("MiniDrone");
        foreach (GameObject item in miniDronesList)
        {
            item.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}
