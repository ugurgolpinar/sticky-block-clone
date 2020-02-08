using UnityEngine;

public class Movement : MonoBehaviour
{

    public float horizontalSpeed = 10f;
    public float verticalSpeed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(0))
            transform.Translate(Vector3.right * horizontalSpeed * horizontal * Time.deltaTime);

        transform.Translate(Vector3.forward * verticalSpeed * Time.deltaTime);
    }

}
