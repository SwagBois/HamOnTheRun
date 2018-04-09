using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private GameObject[] pigs;
    private int addIndex = 0;
    private int index = 0;
    private int timer = 240;

    // Use this for initialization
    void Start () {
        pigs = new GameObject[3];
        pigs[addIndex++] = this.gameObject;
        
    }
	
	// Update is called once per frame
	void Update () {

        /*for(int i = 1; i < pigs.Length; i++)
        {
            if(pigs[i] != null)
            {
                pigs[i].transform.position = this.transform.position;
                pigs[i].transform.rotation = this.transform.rotation;
            }
        }*/
        timer++;
        //print(timer);

        // can only switch once every 4 seconds.
        if(timer > 240 && Input.GetKey(KeyCode.X))
        {
            //pigs[index].GetComponentInChildren<MeshRenderer>().enabled = false;
            //pigs[index].SetActive(false);
            index++;
            if(index >= addIndex)
            {
                index = 0;
            }
            //pigs[index].SetActive(true);
            timer = 0;
        }

        if (index == 0)
        {
            GetComponentInChildren<Renderer>().material.color = new Color(0.8f, 0.389f, 0.727f, 0.8f);
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //GameObject leftWing = GameObject.Find("Left Wing").gameObject;
            //GameObject rightWing = GameObject.Find("Right Wing").gameObject;
            //leftWing.SetActive(false);
            //rightWing.SetActive(false);
        }
        else if (index == 1)
        {
            GetComponentInChildren<Renderer>().material.color = new Color(255f/255, 192f/255, 203f/255);
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            //GameObject leftWing = GameObject.Find("Left Wing").gameObject;
            //GameObject rightWing = GameObject.Find("Right Wing").gameObject;
            //leftWing.SetActive(true);
            //rightWing.SetActive(true);
        }
        else if (index == 2)
        {
            // TODO. 3rd pig
        }

        //print(index);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            pigs[addIndex++] = other.gameObject;
            other.gameObject.SetActive(false);
        }
    }

    public int getIndex()
    {
        return index;
    }
}

