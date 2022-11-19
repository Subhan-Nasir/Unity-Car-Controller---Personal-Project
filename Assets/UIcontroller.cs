using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class UIcontroller : MonoBehaviour{


    public static bool gamePaused;
        
    public CarController carController;
    public Rigidbody car;

    [Header("")]
    public GameObject pauseMenuUI;
    public GameObject inGameUI;

    [Header("")]
    public TextMeshProUGUI debugText;

    private NewControls controls;
    private float pauseButton;

    void OnEnable(){
        controls.Enable();
        
    }
    void OnDisable(){
        controls.Disable();
    }

    // Start is called before the first frame update
    void Awake(){
        gamePaused = false;
        controls = new NewControls();
        
    }
    void Start(){
        inGameUI.SetActive(true);
        pauseMenuUI.SetActive(false);        
        
        
    }

    // Update is called once per frame
    void Update(){

        int speed = (int) Mathf.Round(car.velocity.magnitude*3.6f);        
        debugText.text = carController.debugText;  

        // pauseButton = controls.CarControls.PauseMenu.ReadValue<float>();
        pauseButton = controls.CarControls.PauseMenu.triggered ? 1:0;
       

        if(pauseButton == 1 & gamePaused == false){
            PauseGame();
        }
        else if(pauseButton == 1 & gamePaused == true){
            ResumeGame();
        }


    }

    public void PauseGame(){
        gamePaused = true;
        pauseMenuUI.SetActive(true);
        inGameUI.SetActive(false);
        Time.timeScale = 0f;

    }

    public void ResumeGame(){
        gamePaused = false;
        pauseMenuUI.SetActive(false);
        inGameUI.SetActive(true);
        Time.timeScale = 1f;

    }

    public void RestartGame(){
        Debug.Log("Restart Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gamePaused = false;
        Time.timeScale = 1f;
    }

    public void LoadOptions(){
        Debug.Log("Options Pressed");
    }

    public void ExitGame(){
        Debug.Log("Exit Pressed");
        Application.Quit();
    }

}
