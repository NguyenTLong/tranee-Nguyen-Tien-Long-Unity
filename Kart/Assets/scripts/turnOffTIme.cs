using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOffTIme : MonoBehaviour
{

    void turnOn()
    {
        gameObject.SetActive(true);
    }

    public void turnOffInAmountOfTime(int time)
    {
        gameObject.SetActive(false);
        Invoke("turnOn", time);
    }
}
