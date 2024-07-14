using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float levelReloadDelaySeconds = 1;

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Ground") {
            Debug.Log("Hit ground");
            Invoke("ReloadScene", levelReloadDelaySeconds);
        }
    }

    //Restarts level if snowboarder hits head
    private void ReloadScene(){
        SceneManager.LoadScene("Snow_Boarder");
    }
}
