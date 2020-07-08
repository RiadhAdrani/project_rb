using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUI_Menus : MonoBehaviour
{
    [HideInInspector] public bool isPaused;
    [HideInInspector] public bool isLoading;
    [HideInInspector] public GameObject PauseMenu;
    [HideInInspector] public GameObject InGameUI;
    [HideInInspector] public GameObject LoadingScreen;
    public LevelManager level;
    public Text loadingPercent;

    void Start()
    {
        isPaused = true;
        isLoading = true;
    }

    void Update()
    {
        if (isLoading) LoadingScreenProgress();
        GameStatus();
        PauseGame();
        ResumeGame();    
    }

    void GameStatus(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused) isPaused = false;
            else isPaused = true;
        }

    }

    void PauseGame(){
        if (isPaused){
            Time.timeScale = 0;
            if (!isLoading){
                PauseMenu.SetActive(true);
                LoadingScreen.SetActive(false);
            }else {
                PauseMenu.SetActive(false);
                LoadingScreen.SetActive(true);
            }
            InGameUI.SetActive(false);
        }
    }

    void ResumeGame(){
        if (!isPaused){
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            InGameUI.SetActive(true);
        }
        
    }

    public void ResumeButton(){
        isPaused = false;
    }

    public void ReloadLevelButton(){
        Debug.Log("ReloadLevelButton Clicked");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
 

    public void QuitGameButton(){
        Debug.Log("QuitButton Clicked");
        SceneManager.LoadScene("0_Main_Menu");
    }

    void LoadingScreenProgress(){
        loadingPercent.text = "Loading ...";
        if (level.level_step == level.level_length) {isLoading = false;LoadingScreen.SetActive(false);isPaused = false;}
        }
        
    
}
