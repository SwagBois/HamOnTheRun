using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float speed = 5;
    public GameObject mainCamera;
    private Vector3[][] direction;
    private PlayerController player;
	private Animator anim;
    private Rigidbody rb;
    private int[] count;
    private bool isGrounded = true;
    public bool isDead = false;

    // Use this for initialization
    void Start () {
        player = GetComponent<PlayerController>();
        Vector3[] d0 = new Vector3[4] {Vector3.right, Vector3.left, Vector3.forward, Vector3.back };
        Vector3[] d1 = new Vector3[4] { Vector3.back, Vector3.forward, Vector3.right, Vector3.left };
        Vector3[] d2 = new Vector3[4] { Vector3.left, Vector3.right, Vector3.back, Vector3.forward };
        Vector3[] d3 = new Vector3[4] { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        direction = new Vector3[4][];
        direction[0] = d0;
        direction[1] = d1;
        direction[2] = d2;
        direction[3] = d3;

        count = new int[4];

		anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
		anim.SetBool ("isWalking",false);
    }
	
	// Update is called once per frame
	void Update () {
        int index = mainCamera.GetComponent<CameraController>().getIndex();
        if (isDead)
            return;
		anim.SetBool ("isWalking",false);
        if (Input.GetKey(KeyCode.D))
        {
            /*if(count[0] == 0)
            {
                GameObject.Find("Armature").transform.Rotate(0, 0, 90);

                count[0]++;
            }*/
            if (!isGrounded)
                transform.Translate(speed / 2 * direction[index][0] * Time.deltaTime);
            else
                transform.Translate(speed * direction[index][0] * Time.deltaTime);
            anim.SetBool ("isWalking",true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            /*count[0] = 0;
            count[2] = 0;
            count[3] = 0;
            if (count[1] == 0)
            {
                GameObject.Find("Armature").transform.Rotate(0, 0, -90);
                count[1]++;
            }*/
            if (!isGrounded)
                transform.Translate(speed / 2 * direction[index][1] * Time.deltaTime);
            else
                transform.Translate(speed * direction[index][1] * Time.deltaTime);
            anim.SetBool ("isWalking",true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            /*if (count[2] == 0)
            {
                count[0] = 0;
                count[1] = 0;
                count[3] = 0;
                GameObject.Find("Armature").transform.Rotate(0, 0, 0);
                count[2]++;
            }*/
            if (!isGrounded)
                transform.Translate(speed / 2 * direction[index][2] * Time.deltaTime);
            else
                transform.Translate(speed * direction[index][2] * Time.deltaTime);
            anim.SetBool ("isWalking",true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            /*if (count[3] == 0)
            {
                count[0] = 0;
                count[1] = 0;
                count[2] = 0;
                GameObject.Find("Armature").transform.Rotate(0, 0, 180);
                count[3]++;
            }*/
            if (!isGrounded)
                transform.Translate(speed/2 * direction[index][3] * Time.deltaTime);
            else
                transform.Translate(speed * direction[index][3] * Time.deltaTime);
			anim.SetBool ("isWalking",true);
        }

        if(player.getIndex() == 1 && Input.GetKey(KeyCode.Space))
        {
            float thrust;
            if (isGrounded)
            {
                thrust = Input.GetAxis("Jump") * 5f;
                rb.AddForce(transform.up * thrust, ForceMode.Impulse);
                isGrounded = false;
            }
			anim.SetBool ("isWalking",true);
        }

    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
        else if (c.gameObject.tag == "Magma")
        {
            isGrounded = false;
            isDead = true;
            anim.SetBool("isWalking", false);
            StartCoroutine(PigDiedViaLava());
        }
        else if (GameObject.Find("Robot Enemy") == c.gameObject)
        {
            isDead = true;
            anim.SetBool("isWalking", false);
            StartCoroutine(PigDiedViaRobot());
        }
            
    }

    private IEnumerator PigDiedViaRobot()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        this.transform.position = GameObject.Find("Stage 1 Checkpoint").transform.position;
        isDead = false;
    }

    private IEnumerator PigDiedViaLava()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        this.transform.position = GameObject.Find("Stage 2 Checkpoint").transform.position;
        isDead = false;
    }

    void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "Floor")
            isGrounded = false;
    }
}
