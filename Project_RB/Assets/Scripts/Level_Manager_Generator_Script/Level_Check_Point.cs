using UnityEngine;

public class Level_Check_Point : MonoBehaviour
{
    public bool first_time;
    public Level_Generator platform;
    public Level level;
    void Start()
    {
        first_time = true;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (first_time && other.CompareTag("Player")){
            other.GetComponent<Player>().Player_Stats.CurrentCheckPoint = gameObject.transform;
            level.Level_Settings.check_point_in = platform.platform_num;
            level.Menu.InformationTrigger(level.Menu.check_point_string,level.Menu.display_check_point_time);
            first_time = false;
        }
    }
}
