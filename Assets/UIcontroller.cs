using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class UIcontroller : MonoBehaviour{


    public static bool gamePaused;
    
    public GameObject[] carList;
    public int startingCar = 1;

    [HideInInspector()]
    public CarController carController;
    [HideInInspector()]
    public Rigidbody carRigidBody;

    [Header("")]
    public GameObject pauseMenuUI;
    public GameObject inGameUI;
    public GameObject optionsUI;

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
        int carIndex = PlayerPrefs.GetInt("carIndex");  

        for(int i = 0; i<carList.Length; i++){
            carList[i].SetActive(false);
        }              
        carList[carIndex].SetActive(true);
        Debug.Log($"Spawning car: {carIndex}");
        carController = carList[carIndex].GetComponent<CarController>();
        carRigidBody = carList[carIndex].GetComponent<Rigidbody>();
        
        inGameUI.SetActive(true);
        pauseMenuUI.SetActive(false);   
        optionsUI.SetActive(false);     
        
        
    }

    // Update is called once per frame
    void Update(){

        int speed = (int) Mathf.Round(carRigidBody.velocity.magnitude*3.6f);        
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

    public void ActivateCar(int carIndex){

        PlayerPrefs.SetInt("carIndex", carIndex);
        PlayerPrefs.Save();
        Debug.Log($"NEW CAR SELECTED: ID {carIndex}");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);                
        gamePaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        RestartGame();

    }

    

    public void PauseGame(){
        gamePaused = true;
        pauseMenuUI.SetActive(true);
        inGameUI.SetActive(false);
        optionsUI.SetActive(false);
        Time.timeScale = 0f;
        AudioListener.pause = true;

    }

    public void ResumeGame(){
        gamePaused = false;
        pauseMenuUI.SetActive(false);
        optionsUI.SetActive(false);
        inGameUI.SetActive(true);
        Time.timeScale = 1f;
        AudioListener.pause = false;

    }

    public void RestartGame(){
        Debug.Log("Restart Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
        gamePaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void LoadOptions(){
        optionsUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        inGameUI.SetActive(false);
        Debug.Log("Options Pressed");
    }

    public void ExitGame(){
        Debug.Log("Exit Pressed");
        Application.Quit();
    }

    public void backButtion(){
        pauseMenuUI.SetActive(true);
        optionsUI.SetActive(false);
        inGameUI.SetActive(false);
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

}
