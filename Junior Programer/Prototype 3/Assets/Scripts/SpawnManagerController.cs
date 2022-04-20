using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerController : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    float spawnAfter = 2;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawObstacle", spawnAfter);
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            Invoke("SpawObstacle", Random.Range(3f, 5f));
        }

        
    }
}
