using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody; //The rigid body on our object
    [SerializeField] float torqueAmount = 1f; //amount of torque applied to character
    
    
    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        //if we push arrows we will add torque in either direction
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            rigidbody.AddTorque(torqueAmount  * Time.deltaTime);
        } 
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            rigidbody.AddTorque(-torqueAmount * Time.deltaTime);
        }
    }
}
