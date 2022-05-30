using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    #region Variables

    private Vector2 m_lastMousePos;
    private Vector2 m_currentMousePos;

    private bool m_isRolating;

    private GameController gameController;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.gameState == 1)
        {
            RolatingPipe();
        }
    }



    private void RolatingPipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_isRolating = true;
            m_lastMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0) && m_isRolating)
        {
            m_currentMousePos = Input.mousePosition;

            transform.eulerAngles += new Vector3(0, 0, m_lastMousePos.x - m_currentMousePos.x);

            m_lastMousePos = m_currentMousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            m_isRolating = false;
        }
    }
}
