using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float jumpForce = 2.0f;

    Rigidbody playerRigidbody;
    Vector3 movement;
    PlayerController player;

    float forwardMaxSpeed = 5f;
    float turnMaxSpeed = 80f;

    private float filteredForwardInput = 0f;
    private float filteredTurnInput = 0f;

    public float forwardInputFilter = 5f;
    public float turnInputFilter = 5f;

    private float inputForward = 0f;
    private float inputTurn = 0f;

    private bool isgrounded;

    // Use this for initialization
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        player = GetComponent<PlayerController>();
        isgrounded = false;
    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Floor")
        {
            isgrounded = true;
        }
    }

    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Floor")
        {
            isgrounded = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

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

        if (player.getIndex() == 1 && Input.GetKey(KeyCode.Space) && isgrounded)
        {
            playerRigidbody.AddForce(new Vector3(0.0f, 3.0f, 0.0f) * jumpForce, ForceMode.Impulse);
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
