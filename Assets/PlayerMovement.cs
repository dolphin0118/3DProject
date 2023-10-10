using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody playerRigid;
    float moveSpeedValue = 5f;
    float gravity = -9.81f;
    float JumpValue = 10;
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    
    void Update() {
        FixedAccelerate();
        Jump();
    }

    void FixedAccelerate() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float xSpeed = horizontalInput * moveSpeedValue;
        float ySpeed = gravity * Time.deltaTime* moveSpeedValue;
        float zSpeed = verticalInput * moveSpeedValue;
        playerRigid.velocity = new Vector3(xSpeed, ySpeed, zSpeed);
    }

    void Jump() {
        bool isGround = true;
        if(Input.GetKeyDown(KeyCode.Space) && isGround) {
            float ySpeed = JumpValue;
            playerRigid.velocity = new Vector3(playerRigid.velocity.x, ySpeed, playerRigid.velocity.z);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "ground") {
            JumpValue = 1;
        }
    }
}
