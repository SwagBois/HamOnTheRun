using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y + -3.0f,
            player.transform.position.z + 4.0f
        );
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate () {
        float desiredAngle = player.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = player.transform.position - (rotation * offset);
        transform.LookAt(player.transform);
    }
}
