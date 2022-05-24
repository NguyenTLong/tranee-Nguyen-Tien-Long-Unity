using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public Camera cam;

    [SerializeField]
    private float radius;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || true)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Collider[] colliders = Physics.OverlapSphere(hit.point, radius);

                foreach (Collider collider in colliders)
                {
                    StartCoroutine(turnUp(collider));
                }
                Debug.Log(colliders.Length);
            }
        }
    }

    IEnumerator turnUp(Collider collider)
    {
        collider.gameObject.transform.position += new Vector3(0, 1, 0);
        yield return new WaitForSeconds(1);

        collider.gameObject.transform.position += new Vector3(0, -1, 0);
    }
}
