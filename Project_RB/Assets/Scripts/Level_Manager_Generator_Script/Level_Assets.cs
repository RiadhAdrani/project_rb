using UnityEngine;

public class Level_Assets : MonoBehaviour
{
    public Level level;
    public GameObject[] level_decoration_1,level_decoration_2,level_decoration_3;
    
    void Start()
    {
        level = GetComponent<Level>();
    }

    
}
