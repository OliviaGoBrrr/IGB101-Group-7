using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour{
    
    GameManager gameManager;

    // Start is called before the first frame update
    void Start(){

        //Establish connection between GameManager and script
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update(){
        

    }

    // If player is in collision with objects (with triggers enabled)
    private void OnTriggerEnter(Collider otherObject){
        if(otherObject.transform.tag == "Player")
        {
            gameManager.currentPickups += 1;
            Destroy(this.gameObject);
        }
        
    }
}
