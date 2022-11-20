using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Speedometer : MonoBehaviour{

    public Transform needle;
    public TextMeshProUGUI gearLabel;
    public TextMeshProUGUI speedLabel;
    private CarController carController;
    public Transform labelTemplate;
    public Transform minorTicksTemplate;
    public Image radialBar;
    public Image radialBarBackground;
    public Image redlineBackground;
    public Image outline;
    public GameObject labelsParent;
    // public float redlineRPM = 5500;
    // public float labelAmount = 8;
    public float minorIncrementSize = 0.5f;
    
    
    private float redlineRPM;

    // Subtracting angle makes needle spin clockwise.
    // 0 angle is when needle is pointing to the right hand side.
    public float maxNeedleAngle = -30;  // Angle at maximum RPM.
    public float minNeedleAngle = 220;  // Angle at minimum RPM.

    private float maxRPM;
    private float radialBarFill;
    private float labelAngleRange;
    private int labelAmount;
    private float currentRPM;
    private float currentGear;

    private Color radialBarColour;
    private Color majorTickColour;
    private Color minorTickColour;
    private Color gearLabelColour;
    private Color speedLabelColour;
   
    

    private int speed;
    // Start is called before the first frame update

    void Awake(){

        // carController = gameObject.GetComponentInParent<CarController>();

        // carController = gameObject.transform.parent.gameObject.GetComponent<UIcontroller>().carController;

        

        labelTemplate.gameObject.SetActive(false);
        minorTicksTemplate.gameObject.SetActive(false);
        radialBar.transform.eulerAngles = new Vector3(0,0,minNeedleAngle);
        radialBarBackground.transform.eulerAngles = new Vector3(0,0,minNeedleAngle);
        radialBarBackground.fillAmount = -(maxNeedleAngle - minNeedleAngle)/360f;
        
        labelAngleRange = minNeedleAngle - maxNeedleAngle;
        
        radialBarColour = radialBar.color;
        majorTickColour = labelTemplate.Find("RPM Label Dash").GetComponent<Image>().color;
        minorTickColour = minorTicksTemplate.Find("Dash").GetComponent<Image>().color;
        gearLabelColour = gearLabel.color;
        speedLabelColour = speedLabel.color;
        



    }
    void Start(){
        
        carController  = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<UIcontroller>().carController;
        maxRPM = carController.maxRPM;
        redlineRPM = carController.redlineRPM;
        labelAmount = Mathf.RoundToInt(maxRPM/1000f) + 1;        
        createRPMlabels();
        gearLabel.text = carController.currentGear.ToString();

        speed = (int) Mathf.Round(carController.car.velocity.magnitude*3.6f);
        speedLabel.text = $"{speed.ToString("D3")}";
         

    }

    // Update is called once per frame
    void Update(){
        currentRPM = carController.engineRPM;

        needle.eulerAngles = new Vector3(0,0, getNeedleAngle());
        
        currentGear = carController.currentGear;
        if(currentGear == -1){
            gearLabel.text = "R";
        }
        else if(currentGear == 0){
            gearLabel.text = "N";
        }
        else{
            gearLabel.text = carController.currentGear.ToString(); 

        }
         
        
        speed = (int) Mathf.Round(carController.car.velocity.magnitude*3.6f);
        speedLabel.text = $"{speed.ToString("D3")}";

        radialBarFill = (minNeedleAngle - getNeedleAngle())/(360f);
        radialBar.fillAmount = radialBarFill;

        if(currentRPM >= redlineRPM){
            radialBar.color = Color.red;
            gearLabel.color = Color.red;
            speedLabel.color = Color.red;
            outline.color = Color.red;
            

            // needle.GetChild(0).GetComponent<Image>().color = Color.red;
        }
        else{
            radialBar.color = radialBarColour;
            gearLabel.color = gearLabelColour;
            speedLabel.color = speedLabelColour;
            outline.color = radialBarColour;
            
        }

        

        // Debug.Log($"Fill = {radialBarFill}, needle angle = {getNeedleAngle()}");


        

        
    }


    private float getNeedleAngle(){

        float totalRotation = minNeedleAngle - maxNeedleAngle;
        float normalisedRPM = currentRPM/(labelAmount*1000f);
        return minNeedleAngle - (normalisedRPM * totalRotation);
        

    }


    // For showing speed insted of engine RPM on speedometer;
    // private float getSpeedAngle(){
    //     float totalRotation = minNeedleAngle - maxNeedleAngle;
    //     float normalisedSpeed = carController.car.velocity.magnitude * 3.6f/100;
    //     normalisedSpeed = Mathf.Clamp(normalisedSpeed, 0, 1);
    //     return minNeedleAngle - (normalisedSpeed * totalRotation);

    // }

    void createRPMlabels(){
        // int labelAmount = 8;
        

        for(int i = 0; i<= labelAmount; i++){

            Transform rpmLabel = Instantiate(labelTemplate, labelsParent.transform);

            float labelPositionNormalized = (float)i/labelAmount;
            float labelAngle = minNeedleAngle - labelPositionNormalized * labelAngleRange;
            rpmLabel.eulerAngles = new Vector3(0,0,labelAngle);

            string labelText = (i).ToString();

            rpmLabel.Find("RPM Label Text").GetComponent<TextMeshProUGUI>().text = labelText;
            rpmLabel.Find("RPM Label Text").eulerAngles = new Vector3(0,0,0);
            rpmLabel.gameObject.SetActive(true);

            if(i >= redlineRPM/1000){
                rpmLabel.Find("RPM Label Dash").GetComponent<Image>().color = Color.red;
            }

            
            if(i <= labelAmount-1){
                for(float j = minorIncrementSize; j < 1; j+= minorIncrementSize){
                    Transform minorTickMark = Instantiate(minorTicksTemplate, labelsParent.transform);

                    float markerAngleOffset = j*(labelAngleRange)/(labelAmount);
                    minorTickMark.eulerAngles = new Vector3(0,0,labelAngle - markerAngleOffset);

                    if(i+j >= redlineRPM/1000){
                        minorTickMark.Find("Dash").GetComponent<Image>().color = Color.red;
                    }                       
                    minorTickMark.gameObject.SetActive(true);              
                
                }                
            }       
           
        }

        float redLineStartNormalized = (redlineRPM/1000)/labelAmount;
        
        float redLineAngle = minNeedleAngle - redLineStartNormalized * labelAngleRange;
        redlineBackground.transform.eulerAngles = new Vector3(0,0, redLineAngle);
        redlineBackground.fillAmount = -(maxNeedleAngle - redLineAngle)/360; 
        // Debug.Log($"Fill = {redlineBackground.fillAmount}, angle = {redLineAngle}");



       
    }
}
