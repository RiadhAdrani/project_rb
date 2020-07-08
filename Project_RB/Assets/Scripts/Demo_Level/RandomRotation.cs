using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    private float speed;
    private Vector3 rotation = Vector3.one;

    void Start() {
        speed = 5f;
    }

    void Update()
    {
        this.gameObject.transform.Rotate(rotation*speed*Time.deltaTime,Space.Self);
    }
}
