using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] objSpawns;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] float spawnRangeZ;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnObj());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnObj()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(objSpawns[Random.Range(0, objSpawns.Length)],new Vector3(0,20, Random.Range(-spawnRangeZ, spawnRangeZ)), Quaternion.identity);
        }
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
}
