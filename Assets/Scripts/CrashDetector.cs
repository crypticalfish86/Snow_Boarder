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
    [SerializeField] GameObject snowTrail; //player snowtrail
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
        if (other.gameObject.CompareTag("Ground") && !hitGroundYet) {
            hitGroundYet = true; //prevent double play
            rigidBody.velocity = Vector3.zero; //stop player object movement
            Debug.Log("Hit ground");// console log
            deathEffect.Play(); //particle explosion
            deletePlayer();
            Destroy(cinemachineBrain); //stop camera
            Invoke("reloadScene", levelReloadDelaySeconds); //reload game
        }
    }

    //Restarts level if snowboarder hits head
    private void reloadScene(){
        SceneManager.LoadScene("Snow_Boarder");
    }

    private void deletePlayer(){
            Destroy(head); //delete player head
            Destroy(legs); //delete player bottom
            Destroy(snowTrail);//delete snowboard particle effect
    }
}
