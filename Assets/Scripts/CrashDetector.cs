using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float levelReloadDelaySeconds = 1;
    [SerializeField] ParticleSystem deathEffect; //player explosion
    [SerializeField] GameObject head; //player head
    [SerializeField] GameObject legs;//player legs
    private Rigidbody2D rigidBody; //the physics of the player
    private bool hitGroundYet; //needed to prevent double particle effect

    //needed start to have a non static value for rigidBody
    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();//at game start get the physics
        hitGroundYet = false; //needed to prevent double particle effect
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Ground" && !hitGroundYet) {
            hitGroundYet = true;
            rigidBody.velocity = Vector3.zero;
            Debug.Log("Hit ground");
            deathEffect.Play();
            Destroy(head);
            Destroy(legs);
            Invoke("ReloadScene", levelReloadDelaySeconds);
        }
    }

    //Restarts level if snowboarder hits head
    private void ReloadScene(){
        SceneManager.LoadScene("Snow_Boarder");
    }
}
