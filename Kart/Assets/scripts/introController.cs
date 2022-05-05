using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private bool fadeIn;
    [SerializeField]
    private int fadeInTime;

    [SerializeField]
    private bool fadeOut;

    [SerializeField]
    private bool destroyOnFadeOut;

    [SerializeField]
    private CanvasGroup panel;

    [SerializeField]
    private Camera[] cams;

    private int currentCamIndex = 0;
    void Start()
    {
        cams[currentCamIndex].enabled = true;
        panel.gameObject.SetActive(true);
        fadeIn = true;
        fadeOut = false;
        StartCoroutine(WaitTime(3));
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            panel.alpha -= Time.deltaTime;
            if (panel.alpha <=0)
            {
                fadeIn = false;
            }
        }

        if (fadeOut)
        {
            panel.alpha += Time.deltaTime;
            if (panel.alpha >= 1)
            {
                fadeOut = false;
                fadeIn = true;
                NextCam();
                StartCoroutine(WaitTime(3));
            }
        }
    }

    private void NextCam()
    {
        if (currentCamIndex <= cams.Length)
        {
            cams[currentCamIndex].enabled = false;
            currentCamIndex++;
            try
            {
                cams[currentCamIndex].enabled = true;
            }
            catch (System.Exception)
            {
                EndIntro();
            }
            
        }
    }

    IEnumerator WaitTime(int time)
    {
        yield return new WaitForSeconds(time);
        fadeOut = true;   
    }


    private void EndIntro()
    {
        Debug.Log("The intro is End !!");
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameFlowManager>().StartGame();
        Destroy(gameObject);

    }
}
