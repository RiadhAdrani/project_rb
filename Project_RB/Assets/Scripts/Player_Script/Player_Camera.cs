using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    public Player Player;
    public GameObject Camera;
    public Vector3 Camera_Offset;
    public float Camera_Delay;
    void Start()
    {
        Player = GetComponent<Player>();
    }

    void Update()
    {
        Vector3 Smoothing = Vector3.Lerp(Camera.transform.position, Player.transform.position + Camera_Offset,Camera_Delay);
        Camera.transform.position = Smoothing;
    }
}
