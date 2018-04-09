using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Initial movement controls for Pig based on Rigidbody/CapsuleCollider
[RequireComponent(typeof(Rigidbody))] [RequireComponent(typeof(CapsuleCollider))]
public class PigController : MonoBehaviour
{
    // Movement: rotation - x; thrust - y; velocity - z
    // vertical - initial axis input
    float rotation, thrust, velocity, vertical;

    private bool isGrounded = true;
	private Animator anim;

    Rigidbody rb; CapsuleCollider cc;

    // Initialize components attached to GameObject
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
		anim = GetComponent<Animator>();
    }

    // Initialize connections and interactions with other GameObjects
    void Start()
    {
		anim.SetBool ("isWalking", false);
    }

    // Perform state changes (such as from inputs)
    void Update()
    {
        rotation = Input.GetAxis( "Horizontal" ) * Time.deltaTime * 200.0f;
        thrust = Input.GetAxis( "Jump" ) * Time.deltaTime * 205.0f;
	    vertical = Input.GetAxis ("Vertical");
		if (vertical != 0 || rotation != 0) {
			anim.SetBool ("isWalking", true);
		}

		if ( vertical < 0 )
            velocity = vertical * Time.deltaTime * 5.5f;
		else if ( vertical > 0  )
            velocity = vertical * Time.deltaTime * 8.0f;
    }

    // Performs fixed interval physics updates on RigidBody
    void FixedUpdate()
    {
        transform.Rotate( 0, rotation, 0 );
        transform.Translate( 0, 0, velocity );
	    anim.SetBool ("isWalking", false);
        if ( isGrounded )
            rb.AddForce( transform.up * thrust, ForceMode.Impulse );
    }


    // For now, checks collision using tag for convenience, but can use
    // raycast for other objects

    // TODO: Fix collision and jumping. Right now pig flies/jumps really
    // high on collision with other rigidbodies
    void OnCollisionEnter( Collision c )
    {
        if ( c.gameObject.tag == "Floor" )
            isGrounded = true;
        else if ( c.gameObject.tag == "Magma" )
        {
            this.transform.position = GameObject.Find("Stage 2 Checkpoint").transform.position;
        }

    }

    void OnCollisionExit( Collision c )
    {
        if ( c.gameObject.tag == "Floor" )
            isGrounded = false;
    }
}