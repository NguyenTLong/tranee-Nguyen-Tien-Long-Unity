using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    #region variable

    [SerializeField]
    private float m_moveSpeed;

    [SerializeField]
    private float m_destroyPosittion;

    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, m_moveSpeed * -0.01f));

        if (transform.position.z > 10)
        {

        }
    }

}
