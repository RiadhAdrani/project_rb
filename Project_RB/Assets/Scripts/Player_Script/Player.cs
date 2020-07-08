using UnityEngine;

public class Player : MonoBehaviour
{
    public Player_Mouvement Player_Mouvement;
    public Player_Stats Player_Stats;
    public Player_Camera Player_Camera;
    public GameObject Camera;
    public Player_Score Player_Score;
    public Player_Key_Binding Player_Key_Binding;
    public Rigidbody Rigid_Body;
    public AudioManager Player_Audio;
    public AudioSource Player_Audio_Source;
    public Axes Axes;
    void Start()
    {
        Player_Mouvement = GetComponent<Player_Mouvement>();
        Player_Stats = GetComponent<Player_Stats>();
        Player_Camera = GetComponent<Player_Camera>();
        Player_Score = GetComponent<Player_Score>();
        Player_Key_Binding = GetComponent<Player_Key_Binding>();
        Rigid_Body = GetComponent<Rigidbody>();
        Player_Audio = GetComponent<AudioManager>();
        Player_Audio_Source = GetComponent<AudioSource>();
        Axes = GetComponent<Axes>();
    }
    
}
