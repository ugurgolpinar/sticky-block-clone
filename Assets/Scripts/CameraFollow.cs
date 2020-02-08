using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset = new Vector3(0, 15, -10);

    void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
