using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public GameObject Objects,chkpts;
    public RandomlyGeneratedLevel platform;
    void Start() {
        chkpts.SetActive(false);
        platform = GetComponent<RandomlyGeneratedLevel>();
    }
    
    
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            Objects.SetActive(true);
            chkpts.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")){
            Objects.SetActive(false);
            chkpts.SetActive(false);
        }
    }
}
