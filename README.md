# Unity-Car-Controller---Personal-Project

https://user-images.githubusercontent.com/72516828/211876664-31e10793-630f-4d42-910d-a7fb9a5e45d4.mp4

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

    * To setup a new car (you can use included car as reference):
        * Import a 3d model of a car, ideally as single body and 4 separate wheel meshes. 
        * Attach rigidbody component to the car GameObject.
        * Attach empty game objects at the exact locations of each wheel
        * Attach wheel collider components to the empty and 
        input the right values (roughly 30,000 spring stiffness and 5,000 damping ratio for a 1000kg car).
        * Attach car controller script to the car gameobject
        * Input the necessary values (engine curve, gear ratios etc) and press play.
        
