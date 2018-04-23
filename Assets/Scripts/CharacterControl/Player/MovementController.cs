using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float speed = 5;
    public GameObject mainCamera;
    //private Vector3[][] direction;
    private PlayerController player;
	private Animator anim;
    private Rigidbody rb;
    
    private bool isGrounded;

    // Use this for initialization
    void Start () {
        isGrounded = false;
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        /*Vector3[] d0 = new Vector3[4] {Vector3.right, Vector3.left, Vector3.forward, Vector3.back };
        Vector3[] d1 = new Vector3[4] { Vector3.back, Vector3.forward, Vector3.right, Vector3.left };
        Vector3[] d2 = new Vector3[4] { Vector3.left, Vector3.right, Vector3.back, Vector3.forward };
        Vector3[] d3 = new Vector3[4] { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        direction = new Vector3[4][];
        direction[0] = d0;
        direction[1] = d1;
        direction[2] = d2;
        direction[3] = d3;*/

		anim = GetComponent<Animator>();
		anim.SetBool ("isWalking",false);
    }
	
	// Update is called once per frame
	void Update () {
        int index = mainCamera.GetComponent<CameraController>().getIndex();
        //transform.rotation = mainCamera.transform.rotation;
        transform.eulerAngles = new Vector3(mainCamera.transform.eulerAngles.x - 30, mainCamera.transform.eulerAngles.y, mainCamera.transform.eulerAngles.z);

        anim.SetBool ("isWalking",false);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!isGrounded)
            {
                transform.Translate((2*speed/3) * Vector3.right * Time.deltaTime);
            }
            else
            {
                transform.Translate(speed * Vector3.right * Time.deltaTime);
            }
            anim.SetBool ("isWalking",true);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // transform.Translate(speed * direction[index][1] * Time.deltaTime);
            if (!isGrounded)
            {
                transform.Translate((2*speed/3) * Vector3.left * Time.deltaTime);
            }
            else
            {
                transform.Translate(speed * Vector3.left * Time.deltaTime);
            }
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.Translate(speed * direction[index][2] * Time.deltaTime);
            if (!isGrounded)
            {
                transform.Translate((2*speed/3) * Vector3.forward * Time.deltaTime);
            }
            else
            {
                transform.Translate(speed * Vector3.forward * Time.deltaTime);
            }
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!isGrounded)
            {
                transform.Translate((2*speed/3) * Vector3.back * Time.deltaTime);
            }
            else
            {
                transform.Translate(speed * Vector3.back * Time.deltaTime);
            }
            anim.SetBool("isWalking", true);
        }

        if(player.getIndex() == 1 && Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                isGrounded = false;
                rb.velocity = new Vector3(0, 5, 0);
                anim.SetBool("isWalking", true);
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            return;
        }
        isGrounded = false;
    }
}
