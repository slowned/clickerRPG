using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private float speed = 3;

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    void Update()
    {
        if (playerControllerScript.fighting == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}