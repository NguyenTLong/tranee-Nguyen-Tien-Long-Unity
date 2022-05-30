using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objSpawns;

    [SerializeField]
    private float SpawnDistance;

    [SerializeField]
    private float spawn;

    private GameObject pipe;

    // Start is called before the first frame update
    void Start()
    {
        pipe = GameObject.FindGameObjectWithTag("Pipe");
        InvokeRepeating("SpawnWall", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWall()
    {
        int randomIndex = Random.Range(0, objSpawns.Length);

        GameObject newWall = Instantiate(objSpawns[randomIndex], pipe.transform.position, Quaternion.Euler(0,0, Random.Range(0, 360)));
        newWall.transform.parent = pipe.transform;
    }
}
