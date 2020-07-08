using UnityEngine;

public class Level : MonoBehaviour
{
    public Level_Settings Level_Settings;
    public In_Game_Menu_Handler Menu;
    public Level_OptimizerV2 optimizer_v2;
    public Level_Assets level_assets;

    void Start()
    {
        Level_Settings = GetComponent<Level_Settings>();
        optimizer_v2 = GetComponent<Level_OptimizerV2>();
        level_assets = GetComponent<Level_Assets>();
    }

}
