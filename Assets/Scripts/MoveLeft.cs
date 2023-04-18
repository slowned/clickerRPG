using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {
    private float speed = 3;

    private PlayerController playerControllerScript;

    void Start() {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    void Update() {
        if(playerControllerScript.isFighting == false) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
