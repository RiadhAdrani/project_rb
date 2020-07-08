using UnityEngine;

public class Player_Score : MonoBehaviour
{
    public int Score;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("coin")){
            Score++;
            Destroy(other.gameObject);
        }
    }

}
