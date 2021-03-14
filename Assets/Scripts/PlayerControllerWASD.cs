using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerWASD : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 400.0f;
    private float gravityValue = 0f;
    private float minX = -462;// Left of the screen
    private float maxX = -17; // Right of the screen
    private float minZ = -260; // Bottom of the screen
    private float maxZ = 267; // Top of the screen
    
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        
        gameObject.tag = "Player";
    }

    void Update()
    {
        //groundedPlayer = controller.isGrounded;
        // if (groundedPlayer && playerVelocity.y < 0)
        // {
        //     playerVelocity.y = 0f;
        // }
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //controller.Move(move * Time.deltaTime * playerSpeed);
        //if (move != Vector3.zero)
        //{
            //gameObject.transform.forward = move;
       // }
        // playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
        
        Vector3 currentPosition = transform.position;
        currentPosition.x += Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        currentPosition.y = 0f;
        currentPosition.z += Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        transform.position = currentPosition;

        // Vector3 tijdelijkMinX = transform.position;
        //
        // tijdelijkMinX.x = minX;
        //
        //
        // transform.position = currentPosition;
        // {
        //     Mathf.Clamp(transform.position.x, tijdelijkMinX, maxX);
        //     Mathf.Clamp(transform.position.z, minZ, maxZ);
        // }

    }

    // private void OnCollisionEnter(Collision col)
    // {
    //     if (col);
    // }
}
