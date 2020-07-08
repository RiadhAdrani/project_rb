using UnityEngine;

public class RandomlyGeneratedLevel : MonoBehaviour
{
    public int x = 0;
    public LevelManager level;
    [HideInInspector] public GameObject replika;
    [HideInInspector] public GameObject m,l,rr,Objects;
    private GameObject pos;
    private int p;
    private float hmax = 0,hmin = 0; private float h;
    private float rmax = 0,rmin = 0; private float r;
    public int platformNum;

    [HideInInspector] public GameObject[] canons = new GameObject[0];
    [HideInInspector] public GameObject Decor;
    [HideInInspector] public GameObject[] decoration_placeholders = new GameObject[0];
    [HideInInspector] public GameObject[] decoration_samples = new GameObject[0];
    [HideInInspector] public GameObject checkPt;
    [HideInInspector] public bool createCheckPoint = true;
    [HideInInspector] public GameObject[] boxingBoxes;
    [HideInInspector] public GameObject[] swipers;
    public GameObject[] roadBlockers;
    public GameObject endPlatform;
    private int i = 0;
    
    void Start()
    {
        platformNum = level.level_step;
        VariableInit();
        RandomPlatforms();
        x++;
    }
    void Update(){
        DestroyPlatform();
    }
    void RandomPlatforms(){
        if (level.level_step < level.level_length){
            h = Random.Range(hmin,hmax);
            r = Random.Range(rmin,rmax);
            p = Random.Range(1,4);
            switch (p){
                case 1: pos = m; break;
                case 2: pos = l; break;
                case 3: pos = rr; break;
                default : pos = m; break;
            }
            var obj = Instantiate(replika,pos.transform.position + new Vector3(0,h,0),Quaternion.Euler(new Vector3(0,r,0)));
            obj.transform.parent = level.transform;
            DecorationSetup();
            level.level_step++;
        }
        else{
            pos = m;
            var obj = Instantiate(endPlatform,pos.transform.position,Quaternion.Euler(0,0,0));

        } 
        RandomCannon();
        RandomBoxingBoxes();
        RandomSwipers();
        RandomRoadBlocker();
        CheckPoint();
        Objects.SetActive(false);
        level.checkPointCounter --;
        
    }
    void RandomCannon(){
        for (i=0;i<canons.Length;i++){
            if (Random.Range(0,100)>100-level.cannonsSpawnChance) canons[i].SetActive(true);
            else Destroy(canons[i]);
        }
        level.cannonsSpawnChance *= level.cannonsFactor;     
    }
    void DecorationSetup(){
        for (i=0;i<33;i++){
            var temp = Instantiate(decoration_samples[Mathf.RoundToInt(Random.Range(0,10))],decoration_placeholders[i].transform.position,Quaternion.Euler(new Vector3(Random.Range(-20,20),Random.Range(-20,20),Random.Range(-20,20))));
            temp.transform.parent = Decor.transform;
        }
    }
    void CheckPoint(){
        if (level.checkPointCounter == 0) createCheckPoint = true;

        if (createCheckPoint) {
            checkPt.gameObject.SetActive(true);
            level.checkPointCounter = level.checkPointFrequency;
            createCheckPoint = false;
            }
        else checkPt.gameObject.SetActive(false);
        
    }
    void RandomBoxingBoxes(){
        for (i=0;i<boxingBoxes.Length;i++){
            if (Random.Range(0,100)>100-level.boxingBoxSpawnChance){
                boxingBoxes[i].SetActive(true);
            }
            else{
                Destroy(boxingBoxes[i]);
            }
        }
        level.boxingBoxSpawnChance *= level.boxingBoxFactor;
    }
    void RandomSwipers(){
        for (i=0;i<swipers.Length;i++){
            if (Random.Range(0,100)>100-level.SwiperChance) swipers[i].SetActive(true);
            else Destroy(swipers[i]);
        }

        level.SwiperChance *= level.SwiperSpawnFactor;
    }

    void RandomRoadBlocker(){
        for (i=0;i<roadBlockers.Length;i++){
            if (Random.Range(0,100)>100-level.RoadBlockerChance) roadBlockers[i].SetActive(true);
            else Destroy(roadBlockers[i]);
        }

        level.RoadBlockerChance *= level.RoadBlockerFactor;
    }
    void VariableInit(){
        hmin = level.platformHeight.x;
        hmax = level.platformHeight.y;
        rmin = level.platformRotation.x;
        rmax = level.platformRotation.y;
    }
    void DestroyPlatform(){
        if (level.toDestroyPlatform > platformNum && platformNum != 0) Destroy(gameObject); 
    }
}
