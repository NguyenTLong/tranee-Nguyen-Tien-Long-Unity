using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    #region Edited Variable
    [SerializeField]
    private GameObject scrollbar;

    [Header("Scale")]
    [SerializeField]
    private bool isScale;

    [SerializeField]
    private float scaleSpeed = 0.01f;

    [Header("Rotate")]
    [SerializeField]
    private bool isRotate;

    [SerializeField]
    private float rotateSpeed = 0.01f;
    #endregion

    #region Variable
    private float scroll_pos = 0;
    private float[] pos;
    private float distance;


    private int currentIndexOfScroll = 0;
    private int lastIndexOfScroll;
    #endregion

    #region Build-in Func
    void Start()
    {
        pos = new float[transform.childCount];
        distance = 1f / (pos.Length - 1f);
        Debug.Log(distance);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

    }

    void Update()
    {

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                currentIndexOfScroll = i;
/*                Debug.Log(currentIndexOfScroll);*/
                break;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            lastIndexOfScroll = currentIndexOfScroll;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[currentIndexOfScroll], 0.1f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (lastIndexOfScroll != currentIndexOfScroll)
            {
                OnIndexChange();
            }
        }

        if (isScale)
        {
            SetScale(transform, currentIndexOfScroll);
        }

        if (isRotate)
        {
            SetEulerAngle(transform, currentIndexOfScroll);
        }
    }
    #endregion

    #region Func

    private void SetScale(Transform i_transform, int i_currentIndexOfScroll)
    {
        
        
        

        // last Child scale
        if (i_currentIndexOfScroll > 0)
        {
            Transform lastChild = i_transform.GetChild(i_currentIndexOfScroll - 1);
            lastChild.localScale = Vector2.Lerp(lastChild.localScale, new Vector2(1f, 1f), scaleSpeed);
        }

        // current child scale
        Transform currentChild = i_transform.GetChild(i_currentIndexOfScroll);
        currentChild.localScale = Vector2.Lerp(currentChild.localScale, new Vector2(1.2f, 1.2f), scaleSpeed);

        // next child scale
        if (i_currentIndexOfScroll < pos.Length - 1)
        {
            Transform nextChild = i_transform.GetChild(i_currentIndexOfScroll + 1);
            nextChild.localScale = Vector2.Lerp(nextChild.localScale, new Vector2(1f, 1f), scaleSpeed);
        }
    }

    private void SetEulerAngle(Transform i_transform, int i_currentIndexOfScroll)
    {
        if (i_currentIndexOfScroll > 0)
        {
            Transform lastChild = i_transform.GetChild(i_currentIndexOfScroll - 1);

            if (lastChild.eulerAngles.y > 180)
            {
                lastChild.eulerAngles = Vector3.Lerp(lastChild.eulerAngles - new Vector3(0, 360, 0), new Vector3(0, 15, 0), rotateSpeed);
            }
            else
            {
                lastChild.eulerAngles = Vector3.Lerp(lastChild.eulerAngles, new Vector3(0, 15, 0), rotateSpeed);
            }

        }

        Transform currentChild = i_transform.GetChild(i_currentIndexOfScroll);

        if (currentChild.eulerAngles.y > 180)
        {
            currentChild.eulerAngles = Vector3.Lerp(currentChild.eulerAngles, new Vector3(0, 360, 0), rotateSpeed);
        }
        else
        {
            currentChild.eulerAngles = Vector3.Lerp(currentChild.eulerAngles, new Vector3(0, 0, 0), rotateSpeed);
        }

        if (i_currentIndexOfScroll < pos.Length - 1)
        {
            Transform nextChild = i_transform.GetChild(i_currentIndexOfScroll + 1);

            if (nextChild.eulerAngles.y > 180)
            {
                nextChild.eulerAngles = Vector3.Lerp(nextChild.eulerAngles - new Vector3(0, 360, 0), new Vector3(0, -15, 0), rotateSpeed);
            }
            else
            {
                nextChild.eulerAngles = Vector3.Lerp(nextChild.eulerAngles, new Vector3(0, -15, 0), rotateSpeed);
            }
        }


        if (i_currentIndexOfScroll > 1)
        {
            Transform lastChild2 = i_transform.GetChild(i_currentIndexOfScroll - 2);
            if (lastChild2.eulerAngles.y > 180)
            {
                lastChild2.eulerAngles = Vector3.Lerp(lastChild2.eulerAngles, new Vector3(0, 360, 0), rotateSpeed);
            }
            else
            {
                lastChild2.eulerAngles = Vector3.Lerp(lastChild2.eulerAngles, new Vector3(0, 0, 0), rotateSpeed);
            }
            lastChild2.localScale = Vector2.Lerp(lastChild2.localScale, new Vector2(0.9f, 0.9f), scaleSpeed);
        }

        if (i_currentIndexOfScroll < pos.Length - 2)
        {
            Transform nextChild2 = i_transform.GetChild(i_currentIndexOfScroll + 2);
            if (nextChild2.eulerAngles.y > 180)
            {
                nextChild2.eulerAngles = Vector3.Lerp(nextChild2.eulerAngles, new Vector3(0, 360, 0), rotateSpeed);
            }
            else
            {
                nextChild2.eulerAngles = Vector3.Lerp(nextChild2.eulerAngles, new Vector3(0, 0, 0), rotateSpeed);
            }
            nextChild2.localScale = Vector2.Lerp(nextChild2.localScale, new Vector2(0.9f, 0.9f), scaleSpeed);
        }

    }

    public void Next() {
        if (currentIndexOfScroll < pos.Length - 1)
        {
            scroll_pos = pos[currentIndexOfScroll + 1];
        }
    }

    public void Previous()
    {
        if (currentIndexOfScroll > 0)
        {
            scroll_pos = pos[currentIndexOfScroll - 1];
        }
    }

    private void OnIndexChange()
    {
        Debug.Log("index Change!!");
    }

    #endregion

}   
