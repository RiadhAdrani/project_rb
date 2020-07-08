using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public LevelManager level;
    public GameObject check;
    public int platformNum;

    void Start() {
        platformNum = GetComponentInParent<RandomlyGeneratedLevel>().platformNum;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            level.checkPoint = check.transform;
            level.toDestroyPlatform = platformNum;
        }
    }
}
