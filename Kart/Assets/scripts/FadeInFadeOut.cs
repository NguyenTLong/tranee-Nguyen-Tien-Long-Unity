using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInFadeOut : MonoBehaviour
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
    void Start()
    {
        fadeIn = false;
        fadeOut = false;
        destroyOnFadeOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            panel.alpha += Time.deltaTime;
            if (panel.alpha >=1)
            {
                fadeIn = false;
            }
        }

        if (fadeOut)
        {
            panel.alpha -= Time.deltaTime;
            if (panel.alpha <= 0)
            {
                fadeOut = false;
                if (destroyOnFadeOut)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
