using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 3;

    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject gameOver;
    public GameObject title;

    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        
        score = 0;
        SetScore(score);

        isGameActive = true;
        StartCoroutine(SpawnTarget());
        gameOver.SetActive(false);
        title.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    private void SetScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int value)
    {
        this.score += value;
        scoreText.text = "Score: " + this.score;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        title.SetActive(false);
    }
}
