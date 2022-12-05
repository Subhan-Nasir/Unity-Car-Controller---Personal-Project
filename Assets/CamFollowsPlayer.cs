using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CamFollowsPlayer : MonoBehaviour {
 
    // public Transform cameraTarget;
    // public float sSpeed = 10.0f;
    // public Vector3 dist;
    // public Transform lookTarget;
 
    // void FixedUpdate() {
    //     Vector3 dPos = cameraTarget.position + dist;
    //     Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
    //     transform.position = sPos;
    //     transform.LookAt(lookTarget.position);
    // }

////////////////////////////////////////////////////////////
    // public GameObject attachedVehicle;
    // private CarController carController;
    // private Transform originalTransform;
    // private float carSpeedKPH;
    
    // [Range(0,1)] public float smoothTime = 0.5f;

    // void Start(){
    //     carController = attachedVehicle.GetComponent<CarController>();
    //     originalTransform = transform;

    // }

    // void FixedUpdate(){
    //     transform.position = originalTransform.position * (1-smoothTime) + transform.position * smoothTime;
    //     transform.LookAt(transform);
    //     carSpeedKPH = carController.car.velocity.magnitude * 3.6f; 
    //     smoothTime = (carSpeedKPH > 150) ? Mathf.Abs((carSpeedKPH)/150) - 0.85f : 0.45f;
    // }

///////////////////////////////////////////////////////////////////

    Transform rootNode;
    public Transform carCam;
    public Transform car;
    public Rigidbody carPhysics;

    [Tooltip("If car speed is below this value, then the camera will default to looking forwards.")]
    public float rotationThreshold = 1f;
    
    [Tooltip("How closely the camera follows the car's position. The lower the value, the more the camera will lag behind.")]
    public float cameraStickiness = 10.0f;
    
    [Tooltip("How closely the camera matches the car's velocity vector. The lower the value, the smoother the camera rotations, but too much results in not being able to see where you're going.")]
    public float cameraRotationSpeed = 5.0f;

    void Awake()
    {
        // carCam = Camera.main.GetComponent<Transform>();
        rootNode = GetComponent<Transform>();
        // car = rootNode.parent.GetComponent<Transform>();
        // carPhysics = car.GetComponent<Rigidbody>();
    }

    void Start()
    {
        // Detach the camera so that it can move freely on its own.
        // rootNode.parent = null;
    }

    void FixedUpdate()
    {
        Quaternion look;

        // Moves the camera to match the car's position.
        rootNode.position = Vector3.Lerp(rootNode.position, car.position, cameraStickiness * Time.fixedDeltaTime);

        // If the car isn't moving, default to looking forwards. Prevents camera from freaking out with a zero velocity getting put into a Quaternion.LookRotation
        if (carPhysics.velocity.magnitude < rotationThreshold)
            look = Quaternion.LookRotation(car.forward);
        else
            look = Quaternion.LookRotation(carPhysics.velocity.normalized);
        
        // Rotate the camera towards the velocity vector.
        look = Quaternion.Slerp(rootNode.rotation, look, cameraRotationSpeed * Time.fixedDeltaTime);                
        rootNode.rotation = look;
    }

     
}