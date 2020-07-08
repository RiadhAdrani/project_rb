using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    public int level_length = 10;
    [HideInInspector] public int level_step = 0;
    [HideInInspector] public float LoadingPercent;
    [HideInInspector] public Transform checkPoint;
    public int checkPointFrequency = 10;
    [HideInInspector]public float deathPenalty = 0f;
    [HideInInspector] public int checkPointCounter ;
    [HideInInspector] public bool destroyPlatform = false;
    [HideInInspector] public int toDestroyPlatform;

    public Vector2 platformHeight;
    public Vector2 platformRotation;

    [HideInInspector] public PlayerScore score = null;

    public float cannonsSpawnChance;
    [HideInInspector] public float cannonsFactor = 1.0025f;
    public float boxingBoxSpawnChance;
    [HideInInspector] public float boxingBoxFactor;
    public float SwiperChance;
    [HideInInspector] public float SwiperSpawnFactor;
    public float RoadBlockerChance;
    [HideInInspector] public float RoadBlockerFactor;


    void Start() {
        toDestroyPlatform = -1;
        checkPointCounter = checkPointFrequency;
    }

    void Update() {
        LoadingPercent = (level_step/level_length)*100;
    }
    
}

    
