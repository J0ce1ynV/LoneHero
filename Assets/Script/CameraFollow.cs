using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed
        );

        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10f);
        //-10f agar semua objek nampak
    }
}




/*
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    public Vector3 offset;
    
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
    }
}
*/