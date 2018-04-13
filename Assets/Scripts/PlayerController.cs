using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody playerRigidbody;
    Vector3 movement;
    
    float forwardMaxSpeed = 5f;
    float turnMaxSpeed = 80f;

    private float filteredForwardInput = 0f;
    private float filteredTurnInput = 0f;

    public float forwardInputFilter = 5f;
    public float turnInputFilter = 5f;

    private float inputForward = 0f;
    private float inputTurn = 0f;

    // Use this for initialization
    void Start () {

        gameObject.GetComponent<Renderer>().material.color = Color.red;

        playerRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Q))
        {
            h = -0.5f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            h = 0.5f;
        }

        filteredForwardInput = Mathf.Clamp(Mathf.Lerp(filteredForwardInput, v,
            Time.deltaTime * forwardInputFilter), -forwardMaxSpeed, forwardMaxSpeed);

        filteredTurnInput = Mathf.Lerp(filteredTurnInput, h,
            Time.deltaTime * turnInputFilter);

        inputForward = filteredForwardInput;
        inputTurn = filteredTurnInput;

        playerRigidbody.MovePosition(playerRigidbody.position + this.transform.forward * inputForward * Time.deltaTime * forwardMaxSpeed);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * Quaternion.AngleAxis(inputTurn * Time.deltaTime * turnMaxSpeed, Vector3.up));

    }
}
