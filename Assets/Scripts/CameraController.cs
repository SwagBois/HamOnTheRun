using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    //public float speed = 200f;
    private float rotation = 0f;
    private Quaternion targetRotation;
    private Vector3[] offset;
    private Vector3[] cameraPos;
    private int index = 0;

    // Use this for initialization
    void Start()
    {
        rotation = transform.rotation.eulerAngles.y;
        offset = new Vector3[4];
        offset[0] = new Vector3(-3, 0, 0);
        offset[1] = new Vector3(0, 1.5f, 0);
        offset[2] = new Vector3(3, 0, 0);
        offset[3] = new Vector3(0, 1.5f, 0);
        cameraPos = new Vector3[4];
        cameraPos[0] = new Vector3(4f, 2f, 0);
        cameraPos[1] = new Vector3(0, 2f, -4f);
        cameraPos[2] = new Vector3(-4f, 2f, 0);
        cameraPos[3] = new Vector3(0, 2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current = transform.rotation.eulerAngles;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //rotation -= 90f;
            //targetRotation = Quaternion.Euler(current.x, rotation, current.z);
            //transform.RotateAround(player.transform.position, Vector3.up, 90);
            //offset = new Vector3(6, 0, 0);
            index--;
            if (index < 0)
            {
                index = 3;
            }

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            //rotation += 90f;
            //targetRotation = Quaternion.Euler(current.x, rotation, current.z);
            //offset = new Vector3(-6, 0, 0);
            index++;
        }

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
        //transform.position = player.transform.position + cameraPos[Mathf.Abs(index) % 4];
        transform.position = Vector3.Lerp(transform.position, player.transform.position + cameraPos[index % 4], Time.deltaTime * 3);

        Ray ray = new Ray(transform.position, player.transform.position - transform.position);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Wall")
            {
                transform.position = hit.point;
            }
        }
        //print(transform.localPosition);
        //Vector3 playerPos = player.transform.position + offset[index % 4];
        transform.LookAt(player.transform.position);
       

    }

    public int getIndex()
    {
        return index % 4;
    }





    /*public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y + -3.0f,
            player.transform.position.z + 4.0f
        );
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float desiredAngle = player.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = player.transform.position - (rotation * offset);
        transform.LookAt(player.transform);
    }*/
}