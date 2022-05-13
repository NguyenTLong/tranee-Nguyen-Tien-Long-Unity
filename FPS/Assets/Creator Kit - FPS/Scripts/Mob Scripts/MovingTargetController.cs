using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargetController : MonoBehaviour
{
    public float moveSpeed;

    [SerializeField]
    private float time;

    [SerializeField]
    private float moveRadius;

    Vector3 movingPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        movingPoint = getRandomPosbyRadius();
        Debug.Log( movingPoint +" " + transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        /*        if (Vector3.Distance(transform.position, movingPoint) < 0.1)
                {
                    movingPoint = getRandomPosbyRadius();
                }*/

            transform.Translate( movingPoint * Time.deltaTime,Space.World);

/*        Debug.Log(Vector3.Distance(transform.position, movingPoint));*/

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RoomWall"))
        {
            Debug.Log("face in the Wall");

            movingPoint = getRandomPosbyRadius();
            
            Debug.Log(movingPoint);
        }
    }

    public Vector3 getRandomPosbyRadius()
    {
        return (new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f) , Random.Range(-1f, 1f)) * moveRadius);
    }
}
