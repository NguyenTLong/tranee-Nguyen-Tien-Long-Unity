using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evtTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject board;

    [SerializeField]
    private ParticleSystem[] confetis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        board.SetActive(true);
        foreach (ParticleSystem item in confetis)
        {
            item.Play();
        }
    }
}
