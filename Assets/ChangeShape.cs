using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShape : MonoBehaviour {

    private GameObject selectedShape;
    private GameObject lastselectedShape;
    private GameObject newObject;
    private bool instantiated = false;

	void Update () {
        if(GlobalVariable.MODE == "shape"){
         
            selectedShape = ShapeController.shape;
            if (lastselectedShape && selectedShape != lastselectedShape){
                Destroy(newObject);
                instantiated = false;
            } 
            if (!instantiated)
            {
                newObject = Instantiate(selectedShape, this.transform.position, this.transform.rotation);
                newObject.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
                newObject.transform.parent = this.transform;
                instantiated = true;
                lastselectedShape = selectedShape;
            }
        }
	}
}
