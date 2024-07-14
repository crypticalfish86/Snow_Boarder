using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float levelReloadDelaySeconds = 1; //Delay for level reload

    //Triggered on reaching finish line
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("You Finished!");
            Invoke("ReloadScene", levelReloadDelaySeconds);
        }
    }

    //Reloads level
    private void ReloadScene(){
        SceneManager.LoadScene("Snow_Boarder");
    }
}
