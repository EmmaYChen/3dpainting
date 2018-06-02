using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeController : MonoBehaviour {
    static public GameObject shape;
    public GameObject sShape;

    private Ray ray;

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {

 //       ray = GlobalVariable.selectionRay;
 //       if (GlobalVariable.MODE == "shape")
 //       {
 //           if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
 //           {
 //               RaycastHit hit;
 //               if (GetComponent<Collider>().Raycast(ray, out hit, 500))
 //               {
 //                   if(hit.collider.gameObject.tag == "shape")
 //                      shape = sShape;
 //               }
 //           }
 //       }
	//}

    public void OnShapeButtonClick(){
        if (GlobalVariable.MODE == "shape"){
            shape = sShape;
        }
    }
}
