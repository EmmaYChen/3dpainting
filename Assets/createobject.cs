using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createobject : MonoBehaviour {

    public GameObject cube;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){
            Debug.Log("create an cube");
            Instantiate(cube, transform.position, transform.rotation);
        }
		
	}
}
