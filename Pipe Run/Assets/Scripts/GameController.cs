using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    #region UI variable

    [Header("UI")]
    public GameObject gameOverUI;

    #endregion

    #region Variable

    /// <summary>
    ///  
    /// </summary>
    public int gameState;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        gameState = 0;
        Time.timeScale = 0;

        gameOverUI.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartGame();
            }
        }
    }

    public void StartGame()
    {
        gameState = 1;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        gameState = -2;
        Time.timeScale = 0;
    }
    
    public void ContinueGame()
    {
        gameState = 1;
        Time.timeScale = 1;
    }

    public void EndGame()
    {
        gameState = -1;
        Time.timeScale = 0;

        gameOverUI.SetActive(true);
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
