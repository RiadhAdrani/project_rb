using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public PlayerMouvement player;
    public float score;
    public Text scoreText;
    public LevelManager level;
    public int deathCounter;
    
    void Start()
    {
        deathCounter = 0;
    }

    void Update()
    {
        scoreText.text = "Score: "+Mathf.RoundToInt(score)+" | Speed: "+Mathf.RoundToInt(player.speed-549)+" | Deaths: "+deathCounter;

        if (score<0){
            score = 0;
        }
        
    }

    void DeathPenalty(){
        if (player.dead){
            score -= Mathf.RoundToInt(level.deathPenalty);
        }
    }
}
