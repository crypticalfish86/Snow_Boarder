using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script for player controls
public class PlayerController : MonoBehaviour {
    Rigidbody2D rigidbody; //The rigid body on our object
    [SerializeField] float torqueAmount = 1f; //amount of torque applied to character
    SurfaceEffector2D groundSurfaceEffector; //reference to level surface effector
    
    private float normalSpeed;//normal speed of surface effector
    private float boostSpeed;//bosted speed of surface effector
    
    // Start is called before the first frame update
    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>(); //get rigid body of player
        groundSurfaceEffector = FindObjectOfType<SurfaceEffector2D>(); //get surface effector of ground
        normalSpeed = groundSurfaceEffector.speed; //set normal speed
        boostSpeed = groundSurfaceEffector.speed * 2; //set boosted speed
    }

    // Update is called once per frame
    private void Update() {
        RotatePlayer();
        RespondToBoost();
    }
    
    //if we push arrows/WASD we will add torque in either direction
    private void RotatePlayer() {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            rigidbody.AddTorque(torqueAmount  * Time.deltaTime);
        } 
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            rigidbody.AddTorque(-torqueAmount * Time.deltaTime);
        }
    }

    //If we push up, then double speed of surface effector, otherwise normal speed
    private void RespondToBoost() {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
            groundSurfaceEffector.speed = boostSpeed;
        }
        else{
            groundSurfaceEffector.speed = normalSpeed;
        }
    }
}
