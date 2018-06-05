using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShape : MonoBehaviour {

    private GameObject selectedShape;
    private GameObject lastselectedShape;
    private GameObject newObject;
    private bool instantiated = false;
   // public Transform obposition;
 
	void Update () {
        if(GlobalVariable.MODE == "shape1"){
         
            selectedShape = ShapeController.shape;
            if (lastselectedShape && selectedShape != lastselectedShape){
                Destroy(newObject);
                instantiated = false;
            } 
            if (!instantiated)
            {
                Vector3 Pos = new Vector3(-6f,10f,-6f);
                newObject = Instantiate(selectedShape, this.transform.position,this.transform.rotation);
                newObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
               // newObject.transform.parent = this.transform;
                instantiated = true;
                lastselectedShape = selectedShape;
            }
        }
	}
}
