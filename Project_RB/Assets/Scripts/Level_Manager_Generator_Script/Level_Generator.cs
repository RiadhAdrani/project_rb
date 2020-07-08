using UnityEngine;

public class Level_Generator : MonoBehaviour
{
    public Level level;
    public int platform_num;
    public int level_step;
    public GameObject next_platform;
    public GameObject replika;
    public GameObject[] replika_positions;
    public GameObject ending_platform;
    public GameObject check_point;
    public GameObject[] obstacle_1_positions; // THE RANGED
    public GameObject[] obstacle_2_positions; // THE MEDIUM
    public GameObject[] obstacle_3_positions; // THE SLOWER
    public GameObject[] obstacle_4_positions; // THE ANNOYING
    public GameObject[] obstacle_5_positions; // THE SPECIAL (OPTIONAL)
    public GameObject[] decorations_placeholders_1,decorations_placeholders_2,decorations_placeholders_3;
    public GameObject decoration_empty;

    void Start()
    {
        platform_num = level.Level_Settings.level_step;
        RandomPlatformGenerator();
        CheckPointGenerator();

        if (decorations_placeholders_1.Length != 0 && level.level_assets.level_decoration_1.Length != 0) RandomDecorGenerator(decorations_placeholders_1,level.level_assets.level_decoration_1,decoration_empty.transform,level.Level_Settings.decorations_settings);
        if (decorations_placeholders_2.Length != 0 && level.level_assets.level_decoration_2.Length != 0) RandomDecorGenerator(decorations_placeholders_2,level.level_assets.level_decoration_2,decoration_empty.transform,level.Level_Settings.decorations_settings_2);
        if (decorations_placeholders_3.Length != 0 && level.level_assets.level_decoration_3.Length != 0) RandomDecorGenerator(decorations_placeholders_3,level.level_assets.level_decoration_3,decoration_empty.transform,level.Level_Settings.decorations_settings_3);

        if (obstacle_1_positions.Length > 0) RandomObstacleGenerator(obstacle_1_positions,level.Level_Settings.obstacle_1_setting);
        if (obstacle_2_positions.Length > 0) RandomObstacleGenerator(obstacle_2_positions,level.Level_Settings.obstacle_2_setting);
        if (obstacle_3_positions.Length > 0) RandomObstacleGenerator(obstacle_3_positions,level.Level_Settings.obstacle_3_setting);
        if (obstacle_4_positions.Length > 0) RandomObstacleGenerator(obstacle_4_positions,level.Level_Settings.obstacle_4_setting);
        if (obstacle_5_positions.Length > 0) RandomObstacleGenerator(obstacle_5_positions,level.Level_Settings.obstacle_5_setting);
        
    }

    void RandomPlatformGenerator(){
        if (level.Level_Settings.level_step<level.Level_Settings.level_length){
            var obj = Instantiate(replika,replika_positions[Mathf.RoundToInt(Random.Range(0,replika_positions.Length))].transform.position + new Vector3 (-Random.Range(level.Level_Settings.platform_distance_settings.x,level.Level_Settings.platform_distance_settings.y),Random.Range(level.Level_Settings.height_settings.x,level.Level_Settings.height_settings.y),0),Quaternion.Euler(new Vector3(0,Random.Range(level.Level_Settings.rotation_settings.x,level.Level_Settings.rotation_settings.y),0)));
            if (platform_num != 0 && platform_num != level.Level_Settings.level_length) next_platform = obj;
            obj.transform.parent = level.transform;
            level.Level_Settings.level_step ++;
        }
        else {
            var obj = Instantiate(ending_platform,replika_positions[Mathf.RoundToInt(Random.Range(0,replika_positions.Length))].transform.position,Quaternion.Euler(Vector3.zero)); 
            obj.transform.parent = level.transform;
            }
    }

    void CheckPointGenerator(){
        if (platform_num % level.Level_Settings.check_point_frequency == 0) check_point.gameObject.SetActive(true);
        else check_point.gameObject.SetActive(false);
    }


    void RandomObstacleGenerator(GameObject[] positions,Vector2 Settings){
        int i;
        for (i = 0;i<positions.Length;i++){
            if (Random.Range(0,100)>100-Settings.x) positions[i].SetActive(true);
            else {
                positions[i].SetActive(false);
                Destroy(positions[i]);
                }
        }
        level.Level_Settings.level_difficulty_multiply = true;
    }


    void RandomDecorGenerator(GameObject[] positions,GameObject[] decoration,Transform decoration_empty,Vector3 settings){
        int i = 0;
        for (i=0;i<positions.Length;i++) {
            var obj = Instantiate(decoration[Random.Range(0,decoration.Length)],positions[i].transform.position,Quaternion.Euler(Vector3.zero));
            obj.transform.localScale *= Random.Range(settings.x,settings.y) ;
            obj.transform.localRotation = Quaternion.Euler(new Vector3 (0,Random.Range(-settings.z,settings.z),0)); 
            obj.transform.parent = decoration_empty.transform;
            positions[i].SetActive(false);
            }
    }

}
