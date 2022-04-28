using UnityEngine;

public class RotateOnAxis : MonoBehaviour
{
    [Tooltip("Applies a rotation of eulerAngles.z degrees around the z-axis, eulerAngles.x degrees around the x-axis, and eulerAngles.y degrees around the y-axis (in that order).")]
    public Vector3 rotationSpeed;

    public int rolateRange = 50;

    void Update()
    {


        if (rolateRange != 0)
        {
            Debug.Log(transform.eulerAngles);

            

            if (transform.eulerAngles.y > rolateRange && rotationSpeed.y > 0 && transform.eulerAngles.y < 180)
            {
                transform.eulerAngles = new Vector3(0, rolateRange, 0);
                rotationSpeed *= -1;
            }

            if (transform.eulerAngles.y < 360 - rolateRange && rotationSpeed.y < 0 && transform.eulerAngles.y > 180)
            {
                transform.eulerAngles = new Vector3(0, 360 - rolateRange, 0);
                rotationSpeed *= -1;
            }

        }

        transform.eulerAngles += rotationSpeed;
    }
}
