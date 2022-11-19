using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour{

    [Header("Car Rigid Body")]
    public Rigidbody car;
    public Transform centreOfMass;

    [Header("Wheel Colliders")]
    public WheelCollider frontLeftWC;
    public WheelCollider frontRightWC;
    public WheelCollider rearLeftWC;
    public WheelCollider rearRightWC;

    [Header("Wheel Meshes")]
    public GameObject frontLeftMesh;
    public GameObject frontRightMesh;
    public GameObject rearLeftMesh;
    public GameObject rearRightMesh;
    
    [Header("Wheel Properteis")]
    public float maxTorque = 2310;
    public float maxSteerAngle = 30;
    public float maxBrakingTorque = 1000;
    public float tyrePressure_BAR = 2.75f;
    

    [Header("Steering/Rolling")]
    public float antiRollStiffness = 5000;
    public bool ackermannSteering = true;
    public float turnRaidus = 11.1f;

    [Header("Gearbox")]
    public bool automaticTransmission = false;
    public float gearChangeTime = 0.5f;
    public float finalDriveRatio = 3.25f;
    public float reverseGearRatio = 4.23f;    
    public float[] gearRatios = new float[]{3.72f, 2.40f, 1.77f, 1.26f, 1.00f};
    

    [Header("Engine")]
    public float idleRPM = 1000;
    public float redlineRPM = 5500;
    public float downshiftRPM = 2000;    
    public float engineLossses = 0.2f;
    public float maxEngineBrakingTorque = 100f;
    public AnimationCurve engineCurve;
    
    // private float horizontalInput;
    // private float verticalInput;

    public float wheelTorque{get; set;}
    private float brakingTorque;

    // for Ackermann steering (left and right wheel have different steer angles)
    private float steerAngleLeft;
    private float steerAngleRight;


    private float wheelBase;
    private float rearTrack;
    
    
    public float engineRPM {get;set;}
    public float engineTorque {get; set;}
    public float wheelRPM {get;set;}

    // [HideInInspector]
    // private int currentGear;

    public int currentGear{get; set;}
    
    
    public float maxRPM{get; set;}
    public string debugText{get; set;}

    
    
    private float engineBraking;



    
    private float gearTimer;

    private float travelFL;
    private float travelFR;
    private float travelRL;
    private float travelRR;

    private float previousTravelFL;
    private float previousTravelFR;
    private float previousTravelRL;
    private float previousTravelRR;

    private float springVelocityFL;
    private float springVelocityFR;
    private float springVelocityRL;
    private float springVelocityRR;

    private float loadFL;
    private float loadFR;
    private float loadRL;
    private float loadRR;
    
    
    private float rrCoefficient;

    private float rollingResistanceFL;
    private float rollingResistanceFR;
    private float rollingResistanceRL;
    private float rollingResistanceRR;

    private float frontAxleWeight;
    private float rearAxleWeight;
    
    private float baseLoadFrontWheel;
    private float baseLoadRearWheel;

    
    private float engineAngularVelocity;
    private float engineAngularAcceleration;

    private NewControls controls;

    private float throttle;
    private float brake;
    private float steeringInput; 
    private float handbrake;
    private float esc;
    private bool shiftUp;
    private bool shiftDown;    
    
    private float up;
    private float down;

    private int selectedGear;

    private float previousUp;
    private float previousDown;

    
    private float gearCount; 


    void OnEnable(){
        controls.Enable();
    }

    void OnDisable(){
        controls.Disable();
    }


    // Start is called before the first frame update
    void Awake(){

        controls = new NewControls();

        wheelBase = Vector3.Distance(frontLeftWC.transform.position, rearLeftWC.transform.position);
        rearTrack = Vector3.Distance(rearLeftWC.transform.position, rearRightWC.transform.position);
        car.centerOfMass = centreOfMass.localPosition;
        engineRPM = idleRPM;
        currentGear = 1;
        selectedGear = 1;
        
        maxRPM = engineCurve[ engineCurve.length - 1 ].time;
        gearTimer = gearChangeTime;

        frontAxleWeight = car.mass * Mathf.Abs(centreOfMass.localPosition.z - rearLeftWC.transform.localPosition.z)/wheelBase;
        rearAxleWeight = car.mass - frontAxleWeight;

        baseLoadFrontWheel = 0.5f * frontAxleWeight * Physics.gravity.magnitude;
        baseLoadRearWheel = 0.5f * rearAxleWeight * Physics.gravity.magnitude;
        
        gearCount = gearRatios.Length;

        

    }

    // Update is called once per frame
    void Update(){
        throttle = controls.CarControls.Throttle.ReadValue<float>();
        brake = controls.CarControls.Brake.ReadValue<float>();
        steeringInput = controls.CarControls.Steering.ReadValue<float>();
        handbrake = controls.CarControls.Handbrake.ReadValue<float>();
        
        shiftUp = controls.CarControls.ShiftUp.triggered;
        shiftDown = controls.CarControls.ShiftDown.triggered;

        up = controls.CarControls.ShiftUp.ReadValue<float>();
        down = controls.CarControls.ShiftDown.ReadValue<float>();
        
        if(automaticTransmission){
            if(engineRPM >= 1.1f*redlineRPM & throttle > 0 & currentGear < gearCount){
                up = 1;
            }
            else if(engineRPM <= downshiftRPM & currentGear > 1){
                down = 1;
            }
           


        }
        


        // Debug.Log($"Throttle: {throttle}, UP: {up}, DOWN: {down}");
        

        
    }

    void FixedUpdate(){

        
        if(gearTimer < gearChangeTime){
            throttle = 0;            
        }

        
        applyAntiRollBars();
        calculateWheelLoads();
        calculateRollingResistance();

        float total = (loadFL + loadFR + loadRL + loadRR)/9.81f;
        // Debug.Log($"{travelFL},{travelFR},{travelRL},{travelRR} - Total = {total}");
        

        setCurrentGear();        
        calculateEngineRPM();
        calculateTorque();
        applyTorques();       
        steering();
        updateAllWheelMeshes();       
        

        // debugText = $"RPM:{engineRPM}\n"+
        //             $"Wheel RPM:{wheelRPM}\n"+
        //             $"Gear:{currentGear}\n"+
        //             $"Selected Gear:{selectedGear}\n"+ 
        //             $"Effective Gear Ratio:{findGearRatio(currentGear)*finalDriveRatio}\n"+
        //             $"Engine Braking:{engineBraking}\n"+
        //             $"Engine Torque:{engineTorque}\n"+
        //             $"Wheel Torque:{wheelTorque}\n"+
        //             $"RR Torque:{rollingResistanceRL}\n"+ 
        //             $"Motor Torque:{rearLeftWC.motorTorque}\n"+
        //             $"Brake Torque:{rearLeftWC.brakeTorque}\n"+
                                       
        //             $"Throttle:{throttle} | Brake: {brake}\n"+
        //             $"Steer:{steeringInput}\n";

       
        
    }


    float getSuspensionTravel(WheelCollider collider){

        Vector3 colliderPosition; // includes suspension travel, steering etc.
        Quaternion colliderRotation;
        
        collider.GetWorldPose(out colliderPosition, out colliderRotation);  

        // collider.transform.position excludes suspenion travel, steering etc.      
        float travel = colliderPosition.y - collider.transform.position.y;
        
        return travel;
        

    }
    
    void calculateWheelLoads(){
        

        travelFL = getSuspensionTravel(frontLeftWC);
        travelFR = getSuspensionTravel(frontRightWC);
        travelRL = getSuspensionTravel(rearLeftWC);
        travelRR = getSuspensionTravel(rearRightWC);

        springVelocityFL = (travelFL - previousTravelFL)/Time.fixedDeltaTime;
        springVelocityFR = (travelFR - previousTravelFR)/Time.fixedDeltaTime;
        springVelocityRL = (travelRL - previousTravelRL)/Time.fixedDeltaTime;
        springVelocityRR = (travelRR - previousTravelRR)/Time.fixedDeltaTime;

        loadFL = baseLoadFrontWheel + travelFL * frontLeftWC.suspensionSpring.spring - springVelocityFL * frontLeftWC.suspensionSpring.damper;
        loadFR = baseLoadFrontWheel +travelFR * frontRightWC.suspensionSpring.spring - springVelocityFR * frontRightWC.suspensionSpring.damper;
        loadRL = baseLoadRearWheel +travelRL * rearLeftWC.suspensionSpring.spring - springVelocityRL * rearLeftWC.suspensionSpring.damper;
        loadRR = baseLoadRearWheel +travelRR * rearRightWC.suspensionSpring.spring - springVelocityRR * rearRightWC.suspensionSpring.damper;

        previousTravelFL = travelFL;
        previousTravelFR = travelFR;
        previousTravelRL = travelRL;
        previousTravelRR = travelRR;



    }

    void calculateRollingResistance(){

        rrCoefficient = 0.005f + (1 / tyrePressure_BAR) * (0.01f + 0.0095f * Mathf.Pow(0.01f*3.6f * car.velocity.magnitude, 2));


        rollingResistanceFL = rrCoefficient * loadFL * frontLeftWC.radius;
        rollingResistanceFR = rrCoefficient * loadFR * frontRightWC.radius;
        rollingResistanceRL = rrCoefficient * loadRL * rearLeftWC.radius;
        rollingResistanceRR = rrCoefficient * loadRR * rearRightWC.radius;
        
        if(car.velocity.magnitude <= 0.5f){
            rollingResistanceFL = 0;
            rollingResistanceFR = 0;
            rollingResistanceRL = 0;
            rollingResistanceRR = 0;

        }
    }


    void applyAntiRollBars(){
        
        WheelHit hitRearLeft;
        WheelHit hitRearRight;

        bool groundedLeft = rearLeftWC.GetGroundHit(out hitRearLeft);
        bool groundedRight = rearRightWC.GetGroundHit(out hitRearRight);

        float antiRollForce = (travelRL - travelRR) * antiRollStiffness;
        if(groundedLeft){
            car.AddForceAtPosition(rearLeftWC.transform.up * -antiRollForce, rearLeftWC.transform.position);

        }
        if(groundedRight){
            car.AddForceAtPosition(rearRightWC.transform.up * antiRollForce, rearRightWC.transform.position);
        }



    }

    void steering(){

        if(ackermannSteering){
            if(steeringInput > 0){
                steerAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase/(turnRaidus + 0.5f*rearTrack)) * steeringInput;
                steerAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase/(turnRaidus - 0.5f*rearTrack)) * steeringInput;
            }
            else if(steeringInput < 0){
                steerAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase/(turnRaidus - 0.5f*rearTrack)) * steeringInput;
                steerAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase/(turnRaidus + 0.5f*rearTrack)) * steeringInput;
            }
            else{
                steerAngleLeft = 0;
                steerAngleRight = 0;
            }

        }
        else{
            // for non ackermann, both wheels have the same steer angle
            steerAngleLeft = maxSteerAngle * steeringInput;
            steerAngleRight = steerAngleLeft;
            
        }

        frontLeftWC.steerAngle = steerAngleLeft;
        frontRightWC.steerAngle = steerAngleRight;
 
    }
    
    float findGearRatio(int gear){
        if(gear == -1){
            return reverseGearRatio;
        }
        else if(gear == 0){
            return 0;
        }
        else{
            return gearRatios[gear-1];
        }
    }

    void setCurrentGear(){

        // Gear change doesn't happen instantly, it takes {gearChangeTime} seconds.
        // For example: you cannot change from 2nd to 3rd gear while 
        // 2nd gear is still being engaged/activated. 

        if(gearTimer >= gearChangeTime){

            // Only applies the gear when shiftUp and shiftDown buttons are not being pressed.
            // This prevents you from just holding down shiftUp to go from 1st to 5th.
            // Likewise for shifting down.             
            if(up != 1 & down != 1){
                currentGear = selectedGear;
                currentGear = Mathf.Clamp(currentGear, -1, 5);
            }
            

            if(up == 1 & currentGear == selectedGear){
                selectedGear += 1;
                selectedGear = Mathf.Clamp(selectedGear, -1, 5);
                gearTimer = 0;
            }
            else if(down == 1 & currentGear == selectedGear){
                selectedGear -= 1;
                selectedGear = Mathf.Clamp(selectedGear, -1, 5);
                gearTimer = 0;
            }
        }
        else{
            currentGear = 0;
        }
        
        

        gearTimer += Time.fixedDeltaTime;      
        
    }

    void calculateEngineRPM(){

        wheelRPM = (rearLeftWC.rpm + rearRightWC.rpm)/2;
        float newEngineRPM;
        if(currentGear == -1){
            newEngineRPM = Mathf.Abs(wheelRPM*(reverseGearRatio * finalDriveRatio));
        }
        else if(currentGear > 0){
            newEngineRPM = wheelRPM*(findGearRatio(currentGear) * finalDriveRatio);
            // Debug.Log($"unclamped RPM = {engineRPM}");
        }
        else{
                        
            
            newEngineRPM = wheelRPM * findGearRatio(selectedGear) * finalDriveRatio;

        }
        
        newEngineRPM = Mathf.Clamp(newEngineRPM, idleRPM, maxRPM);
        engineRPM = Mathf.Lerp(engineRPM, newEngineRPM, 0.05f);
        

    }

   
    void calculateTorque(){
        
        // engineBraking = maxEngineBrakingTorque * (1- Mathf.Clamp(verticalInput, 0, 1));
        if(currentGear != -1){
            engineBraking = maxEngineBrakingTorque * (1-throttle);
        }
        else{
            engineBraking = maxEngineBrakingTorque * (1-brake);
        }
        
        

        if(engineRPM <= 1.1*idleRPM | car.velocity.magnitude <= 1){
            engineBraking = 0;
        }

        

        if(currentGear != -1){
            engineTorque = (1-engineLossses) * engineCurve.Evaluate(engineRPM) * throttle - engineBraking;
        }
        else{
            engineTorque = -(1-engineLossses) * engineCurve.Evaluate(engineRPM) * brake + engineBraking;
        }

        if(engineRPM >= maxRPM-500){
            engineTorque = 0;
        }

        
        if(currentGear == -1){
            wheelTorque = (engineTorque * reverseGearRatio * finalDriveRatio )/2;
        }
        else if(currentGear == 0){
            wheelTorque = 0;            
        }
        else{
            wheelTorque = (engineTorque * findGearRatio(currentGear) * finalDriveRatio)/2;
        }

        
        
        
    }

    void applyTorques(){     

        frontLeftWC.motorTorque = -rollingResistanceFL;
        frontRightWC.motorTorque = -rollingResistanceFR;              
        rearLeftWC.motorTorque = wheelTorque - rollingResistanceRL; 
        rearRightWC.motorTorque = wheelTorque - rollingResistanceRR;
          

        if(handbrake > 0){
            frontLeftWC.brakeTorque = 0;
            frontRightWC.brakeTorque = 0;
            rearLeftWC.brakeTorque = maxBrakingTorque;
            rearRightWC.brakeTorque = maxBrakingTorque;
        }
        else{
            if(currentGear >= 0 & brake > 0){
                brakingTorque = maxBrakingTorque * brake;
            }
            else if(currentGear == -1 & throttle > 0){
                brakingTorque = maxBrakingTorque * throttle;
            }
            else{
                brakingTorque = 0;
            }

            frontLeftWC.brakeTorque = brakingTorque;
            frontRightWC.brakeTorque = brakingTorque;
            rearLeftWC.brakeTorque = brakingTorque;
            rearRightWC.brakeTorque = brakingTorque;
        }







    }

    void updateWheelMesh(WheelCollider collider, GameObject mesh){

        Vector3 colliderPosition;
        Quaternion colliderRotation;
        collider.GetWorldPose(out colliderPosition, out colliderRotation);

        mesh.transform.position = colliderPosition;
        mesh.transform.rotation = colliderRotation;

    }

    void updateAllWheelMeshes(){
        updateWheelMesh(frontLeftWC, frontLeftMesh);
        updateWheelMesh(frontRightWC, frontRightMesh);
        updateWheelMesh(rearLeftWC, rearLeftMesh);
        updateWheelMesh(rearRightWC,rearRightMesh);
    }


    

}
