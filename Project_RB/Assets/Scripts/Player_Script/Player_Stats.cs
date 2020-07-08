using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    public Player Player;
    public bool Player_Is_Dead;
    public int Player_Dead_Counter;
    public Transform CurrentCheckPoint;
    void Start()
    {
        Player = GetComponent<Player>();
        Player_Is_Dead = false;
        Player_Dead_Counter = 0;
    }

    void Update()
    {
        Respawn(CurrentCheckPoint);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("fall")) Player_Is_Dead = true;
    }

    void Respawn(Transform CheckPoint){
        if (Player_Is_Dead) {
            Player.Player_Score.Score -= Mathf.RoundToInt(Player.Player_Score.Score/2);
            Player_Dead_Counter ++;
            Player.Rigid_Body.constraints = RigidbodyConstraints.FreezeAll;
            Player_Is_Dead = false;
            gameObject.transform.position = CheckPoint.position;
            Player.Rigid_Body.constraints = RigidbodyConstraints.None;
            }
    }
}
