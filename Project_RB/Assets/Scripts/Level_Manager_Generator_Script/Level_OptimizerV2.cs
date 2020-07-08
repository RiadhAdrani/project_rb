using UnityEngine;

public class Level_OptimizerV2 : MonoBehaviour
{
    public Level level;
    public int current_platform_index;
    public Vector2 range;
    public Vector2 load_range;
    
    
    void Start()
    {
        level = GetComponent<Level>();
    }

    void Update() {
        RangeUpdate();
    }

    void RangeUpdate(){
        load_range.x = current_platform_index - range.x;
        load_range.y = current_platform_index + range.y;
    }
}
