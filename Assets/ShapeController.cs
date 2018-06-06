using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeController : MonoBehaviour {
    static public GameObject shape;
    public GameObject sShape;
    private GameObject newObject;

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
        if (GlobalVariable.MODE == "shape" || GlobalVariable.MODE == "grab"){
            shape = sShape;
            newObject = Instantiate(shape, new Vector3(25f,295f, -38f),Quaternion.identity);
        	newObject.transform.localScale = new Vector3(50f, 50f, 50f);
        }
    }
}
