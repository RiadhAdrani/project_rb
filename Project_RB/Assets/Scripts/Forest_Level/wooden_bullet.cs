using UnityEngine;

public class wooden_bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("fall")) Destroy(gameObject);
    }

}
