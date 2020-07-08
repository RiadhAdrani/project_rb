using UnityEngine;

public class In_Game_Quit_Object : MonoBehaviour
{
    public In_Game_Menu_Handler menu_Handler;
    public GameObject fall_control;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            menu_Handler.end_screen = true;
            fall_control.SetActive(false);
        }
    }
}
