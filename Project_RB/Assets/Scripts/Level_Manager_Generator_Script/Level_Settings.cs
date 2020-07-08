using UnityEngine;

public class Level_Settings : MonoBehaviour
{
    public Level level;
    public int level_length;
    public int level_step;
    public string level_difficulty;
    public bool level_difficulty_multiply;
    public int check_point_frequency;
    public int check_point_in;
    public Vector2 level_length_random;
    public Vector2 level_obstacle_random;
    public Vector2 level_check_point_random;
    public Vector2 platform_distance_settings;
    public Vector2 height_settings;
    public Vector2 rotation_settings;
    public Vector2 obstacle_1_setting;
    public Vector2 obstacle_2_setting;
    public Vector2 obstacle_3_setting;
    public Vector2 obstacle_4_setting;
    public Vector2 obstacle_5_setting;
    public Vector3 decorations_settings;
    public Vector3 decorations_settings_2;
    public Vector3 decorations_settings_3;
    
    
    void Start()
    {
        Version_6();
        check_point_in = -1;
        level_length --;
        level_difficulty_multiply = false;
        level = GetComponent<Level>();
    }

    void Update()
    {
        difficulty_Multiplier();
    }

    void Version_6(){
        level_length = Mathf.RoundToInt(Random.Range(level_length_random.x,level_length_random.y));
        check_point_frequency = Mathf.RoundToInt(Random.Range(level_check_point_random.x,level_check_point_random.y));
        obstacle_1_setting.x = Random.Range(level_obstacle_random.x,level_obstacle_random.y);
        obstacle_2_setting.x = Random.Range(level_obstacle_random.x,level_obstacle_random.y);
        obstacle_3_setting.x = Random.Range(level_obstacle_random.x,level_obstacle_random.y);
        obstacle_4_setting.x = Random.Range(level_obstacle_random.x,level_obstacle_random.y);
        obstacle_5_setting.x = Random.Range(level_obstacle_random.x,level_obstacle_random.y);
    }

    void difficulty_Multiplier(){
        if (level_difficulty_multiply){
            obstacle_1_setting.x *= obstacle_1_setting.y;
            obstacle_2_setting.x *= obstacle_2_setting.y;
            obstacle_3_setting.x *= obstacle_3_setting.y;
            obstacle_4_setting.x *= obstacle_4_setting.y;
            obstacle_5_setting.x *= obstacle_5_setting.y;
            level_difficulty_multiply = false;
        }
    }

    void Custom_Level_Difficulty(){
        
    }

    void Easiest_Level_Difficulty(){
        height_settings = new Vector2(0,0);
        rotation_settings = new Vector2(0,0);
        obstacle_1_setting = new Vector2(5,1.0005f);
        obstacle_2_setting = new Vector2(4,1.0004f);
        obstacle_3_setting = new Vector2(3,1.0004f);
        obstacle_4_setting = new Vector2(2,1.0004f);
        // obstacle_5_setting = new Vector2(1,1.0003f);
    }

    void Easy_Level_Difficulty(){

    }

    void Medium_Level_Difficuly(){

    }

    void Hard_Level_Difficulty(){

    }

    void Hardest_Level_Difficulty(){

    }

    void Impossible_Level_Difficulty(){

    }
}
