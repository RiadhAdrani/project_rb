using UnityEngine;

public class Level_Optimizer : MonoBehaviour
{
    public GameObject platform_content;
    public Level_Generator platform;
    public Collider platform_collider;
    public bool IsActive;
    
    
    void Start()
    {
        IsActive = false;
        platform_content.SetActive(false);
        platform = GetComponent<Level_Generator>();
    }

    void Update() {
        Optimize();
        OptimizeV2();
    }

    void OnCollisionEnter(Collision platform_collider) {
        if (platform_collider.collider.CompareTag("Player")){
            
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            //Activate();
            Indexer();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")){
            //DeActivate();
        }
    }

    void Activate(){
        platform_content.SetActive(true);
        IsActive = true;
    }

    void DeActivate(){
        platform_content.SetActive(false);
        IsActive = false;
    }

    void GapFixer(){
        if (platform.next_platform.GetComponent<Level_Optimizer>().IsActive){
            platform_content.SetActive(true);
            IsActive = true;
        }
    }

    void Optimize(){
        if (platform.platform_num < platform.level.Level_Settings.check_point_in) Destroy(gameObject);
    }

    void OptimizeV2(){
        if (platform.platform_num >= platform.level.optimizer_v2.load_range.x && platform.platform_num <= platform.level.optimizer_v2.load_range.y){
            Activate();
        } else {
            DeActivate();
        }
    }

    void Indexer(){
        platform.level.optimizer_v2.current_platform_index = platform.platform_num;
    }

}
