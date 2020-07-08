using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class In_Game_Menu_Handler : MonoBehaviour
{
    public Level level;
    public Player player;

    public const int loading_screen_status = 0;
    public const int pause_status = 1;
    public const int in_game_status = 2;

    public bool is_paused;
    public bool is_loading;
    public bool end_screen;
    public bool display_info;

    public int game_status;

    public float start_time;
    public float game_time;
    public float display_info_time;
    public float display_check_point_time;
    public float display_info_start_time;
    
    public GameObject pause_menu;
    public GameObject in_game_ui;
    public GameObject exit_ui;
    public GameObject notification_message;
    public GameObject score_ui;
    public GameObject android_specific_control;
    public GameObject loading_screen;
    public GameObject display_info_gameobject;

    public Text notification_text;
    public Text jump_count_text;
    public Text score_text;
    public Text loading_text;
    public Text display_info_text;

    public string game_time_text;
    public string check_point_string;
    
    void Start()
    {
        game_status = loading_screen_status;

        start_time = Time.time;
        
        end_screen = false;
        display_info = false;
        is_loading = true;
        is_paused = true;

        notification_message.SetActive(false);
        exit_ui.SetActive (false);
        display_info_gameobject.SetActive(false);
        
    }

    void Update()
    {
        GameTime();
        TimeFormatter();
        GameStatusHandler();
        InputHandler();
        LoadingScreen();
        GameScreen();
        DisplayInformation();
        PauseScreen();
    }

    void GameTime(){
        if (!end_screen) game_time = Mathf.RoundToInt(Time.time - start_time);
    }

    void InputHandler(){
        if (game_status == pause_status && Input.GetKeyDown(KeyCode.Escape))    {is_paused = false;is_loading = false;} 
        if (game_status == in_game_status && Input.GetKeyDown(KeyCode.Escape))  {is_paused = true;is_loading = false;}
    }

    void GameStatusHandler(){
        if (is_loading && is_paused) game_status = loading_screen_status;
        if (!is_loading && is_paused) game_status = pause_status;
        if (!is_paused && !is_paused) game_status = in_game_status;
    }

    void LoadingScreen(){
        if (game_status == loading_screen_status){
            Cursor.visible = false;
            Time.timeScale = 0;
            loading_screen.SetActive(true);
            in_game_ui.SetActive(false);
            pause_menu.SetActive(false);
            loading_text.text = ""+(level.Level_Settings.level_step / level.Level_Settings.level_length)*100+"%"+"\nLevel Length: "+level.Level_Settings.level_length+"\nCheck Point Frequency: every "+level.Level_Settings.check_point_frequency+" platform"; 
            if (level.Level_Settings.level_step == level.Level_Settings.level_length) {
                is_loading = false;
                is_paused = false;
            }
        }  
    }

    void GameScreen(){
        if (game_status == in_game_status){
            Time.timeScale = 1;
            Cursor.visible = false;
            loading_screen.SetActive(false);
            in_game_ui.SetActive(true);
            pause_menu.SetActive(false);
            if (!end_screen){
                score_ui.SetActive(true);
                score_text.text = "Score: "+player.Player_Score.Score+" | Speed: "+Mathf.RoundToInt(player.Player_Mouvement.Speed) +" | Deaths: "+player.Player_Stats.Player_Dead_Counter+" | Time: "+ game_time_text;
                jump_count_text.text = "Jumps Remaining: "+ player.Player_Mouvement.Jump_Count;
            } else{
                Cursor.visible = true;
                exit_ui.SetActive(true);
                notification_message.SetActive(true);
                score_ui.SetActive(false);
                notification_text.text = "Score: "+player.Player_Score.Score+"\nFails: "+player.Player_Stats.Player_Dead_Counter+"\nTime: "+game_time;
            }
        }
        Android_specific();
    }

    void Android_specific(){
        if (SystemInfo.deviceType == DeviceType.Handheld){
            android_specific_control.SetActive(true);
        }else{
            android_specific_control.SetActive(false);            
        }
    }

    void PauseScreen(){
        if (game_status == pause_status){
            Time.timeScale = 0;
            Cursor.visible = true;
            loading_screen.SetActive(false);
            in_game_ui.SetActive(false);
            pause_menu.SetActive(true);
        }
    }

    public void DisplayInformation(){
        if (display_info){
            display_info_gameobject.SetActive(true);
            display_info_start_time = Time.time;
            display_info = false;
        }
        if (Time.time > display_info_start_time + display_info_time){
            display_info_gameobject.SetActive(false);
        }
    }

    public void InformationTrigger(string message_string,float message_duration){
        display_info = true;
        display_info_text.text = message_string;
        display_info_time = message_duration;
    }


    public void ResumeButton(){
        is_paused = false;
        is_loading = false;
    }

    public void PauseButton(){
        is_paused = true;
        is_loading = false;
    }

    public void GenerateLevelButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenuButton(){
        SceneManager.LoadScene("0_Main_Menu");
    }

    public void NextLevelButton(){
        
    }

    public void TimeFormatter(){
        string minutes = Mathf.Floor(game_time / 60).ToString("00");
        string seconds = (game_time % 60).ToString("00");
        game_time_text = minutes + ":" + seconds;
    }

}
