using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float levelReloadDelaySeconds = 1;
    [SerializeField] ParticleSystem deathEffect; //player explosion
    [SerializeField] GameObject head; //player head
    [SerializeField] GameObject legs;//player legs
    [SerializeField] GameObject Camera; //the camera for the game
    
    private CinemachineBrain cinemachineBrain; //the cinemachine brain for the camera
    private Rigidbody2D rigidBody; //the physics of the player
    private bool hitGroundYet; //needed to prevent double particle effect

    //needed start to have a non static value for rigidBody
    private void Start() {
        cinemachineBrain = Camera.GetComponent<CinemachineBrain>(); //get the logic system of cinemachine
        rigidBody = GetComponent<Rigidbody2D>();//at game start get the physics
        hitGroundYet = false; //needed to prevent double particle effect
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Ground" && !hitGroundYet) {
            hitGroundYet = true; //prevent double play
            rigidBody.velocity = Vector3.zero; //stop player object movement
            Debug.Log("Hit ground");// console log
            deathEffect.Play(); //particle explosion
            Destroy(head); //delete player
            Destroy(legs); //delete player
            Destroy(cinemachineBrain); //stop camera
            Invoke("ReloadScene", levelReloadDelaySeconds); //reload game
        }
    }

    //Restarts level if snowboarder hits head
    private void ReloadScene(){
        SceneManager.LoadScene("Snow_Boarder");
    }
}
