using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private GameObject[] pigs;
    private int addIndex = 0;
    private int index = 0;

    // Use this for initialization
    void Start () {
        pigs = new GameObject[3];
        pigs[addIndex++] = this.gameObject;
        
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.X))
        {
            //pigs[index].GetComponentInChildren<MeshRenderer>().enabled = false;
            
            index++;
            if(index >= addIndex)
            {
                index = 0;
            }
            
        }
        print(index);
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

