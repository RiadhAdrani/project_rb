using UnityEngine;
using UnityEngine.UI;

public class Quitting : MonoBehaviour
{
    public bool exit;
    public bool startTimer;
    public float exitTime = 60f;
    public float _time;
    public Text UpdateMessage;
    public GameObject falling;
    public Player Player;
    public GameObject GameGUI;


    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) exit = true;
        other.attachedRigidbody.AddForce(-2000,0,0);
    }

    void Start() {
        exit = false;
        startTimer = false;
        UpdateMessage.gameObject.SetActive(false);
    }

    void Update()
    {
        QuitGame();
        UpdateMessage.text = "Your Score is : "+Mathf.RoundToInt(Player.Player_Score.Score)+"You failed "+Player.Player_Stats.Player_Dead_Counter+"\nThank you for playing this demo level\nGame exiting automatically in "+Mathf.RoundToInt(_time+exitTime-Time.time)+"\n Made by \"ADRANISOFTWARE\"";
    }

    void QuitGame(){
        if (exit){
            _time = Time.time;
            exit = false;
            GameGUI.SetActive(false);
            UpdateMessage.gameObject.SetActive(true);
            falling.gameObject.SetActive(false);
            startTimer = true;
        }
        if (startTimer){
            if (_time + exitTime < Time.time){
            Application.Quit();        }
        }
        
    }




}
