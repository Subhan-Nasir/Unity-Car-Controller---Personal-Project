# Unity-Car-Controller---Personal-Project

* This is a physics based car controller for Unity.
* Uses wheel colliders instead of raycast so it makes some simplifications.
* Main benefit is that it's easier to setup and use. 
* Allows user to modify properties of engine, transmission, suspension etc. 
* Project already includes a car, two environments, and a UI (work in progress).
    * UI includes:
        * Speedometer
        * Debug text (optional)
        * Menu to pause, restart etc.

    * Environments include: 
        * A mountainous terrain
        * A flat ground (for testing/development).

    * To setup a new car:
        * Import a 3d model of a car, ideally as single body and 4 separate wheel meshes. 
        * Attach rigidbody component to the car GameObject.
        * Attach wheel collider components to all 4 wheels and input the right values.
        * Attach car controller script to the car gameobject
        * Input the necessary values (engine curves, gear ratios etc) and press play.

* Code is currently a work in progress. Comments, explanations and a video demo will be added soon.