using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LoadLevelMenu;
    public GameObject SelectLevelMenu;
    public GameObject OptionsMenu;
    public GameObject HelpMenu;
    public GameObject CustomMessage;

    public bool start_timer;

    public string CustomMessageString;

    public Text CustomMessageText;

    public float MessageTime;
    public float start_time;
    
    public int MenuStatus;
    public const int MainMenuStatus = 0;
    public const int LoadLevelStatus = 1;
    public const int SelectLevelStatus = 2;
    public const int OptionsStatus = 3;
    public const int HelpMenuStatus = 4;


    private void Start() {
        Time.timeScale = 1;
        CustomMessage.SetActive(false);
        MenuStatus = 0;
    }

    private void Update() {
        CustomMessageNotficationTimer();
        Menus_Handler();
    }

    void Menus_Handler(){
        switch (MenuStatus){
            case 0 : MainMenu_Handler(); break;
            case 1 : LoadLevel_Handler(); break;
            case 2 : SelectLevel_Handler(); break;
            case 3 : Options_Handler(); break;
            case 4 : Help_Handler(); break;
            default: MainMenu_Handler(); break;
        }
    }

    void MainMenu_Handler(){
        MainMenu.SetActive(true);
        LoadLevelMenu.SetActive(false);
        SelectLevelMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        HelpMenu.SetActive(false);

    }

    void LoadLevel_Handler(){
        MainMenu.SetActive(false);
        LoadLevelMenu.SetActive(true);
        SelectLevelMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        HelpMenu.SetActive(false);

    }

    void SelectLevel_Handler(){
        MainMenu.SetActive(false);
        LoadLevelMenu.SetActive(false);
        SelectLevelMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        HelpMenu.SetActive(false);

    }

    void Options_Handler(){
        MainMenu.SetActive(false);
        LoadLevelMenu.SetActive(false);
        SelectLevelMenu.SetActive(false);
        OptionsMenu.SetActive(true);
        HelpMenu.SetActive(false);

    }
    
    void Help_Handler(){
        MainMenu.SetActive(false);
        LoadLevelMenu.SetActive(false);
        SelectLevelMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        HelpMenu.SetActive(true);

        EscapeButton(0);
    }

    void EscapeButton(int previous_menu ){
        if (Input.GetKeyDown(KeyCode.Escape)){
            MenuStatus = previous_menu;
        }
    }
    
    public void PlayButton(){
        SceneManager.LoadScene("1_Demo_Level");
    }

    public void PlayForestButton(){
        SceneManager.LoadScene("2_Level_Forest");
    }

    public void HelpButton(){
        MenuStatus = HelpMenuStatus;
    }

    public void EscapeButton(){
        if (MenuStatus != MainMenuStatus) MenuStatus = MainMenuStatus;
    }

    public void QuitButton(){
        Application.Quit();
    }

    public void NotAvailable_Button(){
        CustomMessageNotfication(CustomMessageString);
    }

    public void CustomMessageNotfication(string message){
        CustomMessageText.text = message;
        start_time = Time.time;
        CustomMessage.SetActive(true);
        start_timer = true;
    }

    public void CustomMessageNotficationTimer(){
        if (start_timer && Time.time > (start_time + MessageTime) ){
            start_timer = false;
            CustomMessage.SetActive(false);
        }
    }
}
