using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createobject : MonoBehaviour {

    private GameObject selectedShape;
    private GameObject lastselectedShape;
    private GameObject newObject;
    private bool instantiated = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

         ////old way
         //if (Input.GetMouseButton(0)) // the finger has touched the HMD trackpad.
         //{
         //    Vector2 touchPosition = Input.mousePosition;
         //    Debug.Log("create an cube");
         //    Instantiate(cube, transform.position, transform.rotation);
         //}


        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){
        //    Debug.Log("create an cube");
        //    Instantiate(cube, transform.position, transform.rotation);
        //}
        if(GlobalVariable.MODE == "shape1"){
         
            selectedShape = ShapeController.shape;
            if (lastselectedShape && selectedShape != lastselectedShape){
                Destroy(newObject);
                instantiated = false;
            } 
            if (!instantiated)
            {

                newObject = Instantiate(selectedShape, this.transform.position,this.transform.rotation);
                newObject.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
                newObject.transform.parent = this.transform;
                instantiated = true;
                lastselectedShape = selectedShape;
            }
        }



		
	}
}
