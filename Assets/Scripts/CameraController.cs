using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    //public float speed = 200f;
    private float rotation = 0f;
    private Quaternion targetRotation;
    private Vector3[] cameraPos;
    private int index = 0;

    // Use this for initialization
    void Start()
    {
        rotation = transform.rotation.eulerAngles.y;
        cameraPos = new Vector3[4];
        cameraPos[0] = new Vector3(3.5f, 3.5f, 0);
        cameraPos[1] = new Vector3(0, 3.5f, -3.5f);
        cameraPos[2] = new Vector3(-3.5f, 3.5f, 0);
        cameraPos[3] = new Vector3(0, 3.5f, 3.5f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 current = transform.rotation.eulerAngles;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            index--;
            if (index < 0)
            {
                index = 3;
            }

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            index++;
        }

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

        Vector3 offset = new Vector3(0, 0.6f, 0);
        transform.LookAt(player.transform.position + offset);


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