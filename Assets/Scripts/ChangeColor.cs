using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    public ColorManager cm;
    static public Color sColor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (GlobalVariable.MODE == "color"){
            GetComponent<Renderer>().material.color = cm.color;
            sColor = cm.color; 
        }

	}
}
