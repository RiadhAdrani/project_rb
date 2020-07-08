using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform Camera;
    public Transform ball;
    public Vector3 positionOffset;
    public float smoothSpeed = 1f;
      void LateUpdate()
    {
        Vector3 smoothPosition = Vector3.Lerp(Camera.position,ball.position + positionOffset,smoothSpeed);
        transform.position = smoothPosition;

    }
}
