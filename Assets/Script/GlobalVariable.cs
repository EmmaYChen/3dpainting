using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalVariable : MonoBehaviour
{
    static public Ray selectionRay;
    public Color selectedColor;
    private GameObject selectedShape;
    public GameObject colorsphere;
    public GameObject shapeindicator;
    public Transform obposition;

    public bool interactWithNonUIObjects = true;
    public float rayLength = 1000;
    public Transform trackingSpace = null;
    public LineRenderer lineRenderer = null;
    public UnityEngine.EventSystems.OVRInputModule inputModule = null;


    protected Transform lastHit = null;
    protected Transform triggerDown = null;

    protected OVRInput.Controller activeController = OVRInput.Controller.RTrackedRemote;
    public OVRInput.Button joyPadClickButton = OVRInput.Button.PrimaryIndexTrigger;

    static public string MODE;

    private GameObject selectedItem;
    private Vector2 position;
    private bool rayLengthUp = false;
    private bool rayLengthDown = false;
    private Vector3 previousPosition;
    private float distance;


    private GameObject lastselectedShape;
    private GameObject newObject;
    private bool instantiated = false;
    //private GameObject test;


    // Use this for initialization
    void Start()
    {
        shapeindicator.SetActive(false);
        colorsphere.SetActive(false);
        MODE = "None";

        if (inputModule != null){
            inputModule.OnSelectionRayHit += RayHitSomething;
            joyPadClickButton = inputModule.joyPadClickButton;
        }

        OVRInput.Controller controller = OVRInput.GetConnectedControllers();
        if ((controller & OVRInput.Controller.RTouch) == OVRInput.Controller.RTouch){
            activeController = OVRInput.Controller.RTouch;
        }

        if ((controller & OVRInput.Controller.LTouch) == OVRInput.Controller.LTouch){
            activeController = OVRInput.Controller.LTouch;
        }

        if ((controller & OVRInput.Controller.RTrackedRemote) == OVRInput.Controller.RTrackedRemote){
            activeController = OVRInput.Controller.RTrackedRemote;
        }

        if ((controller & OVRInput.Controller.LTrackedRemote) == OVRInput.Controller.LTrackedRemote)
        {
            activeController = OVRInput.Controller.LTrackedRemote;
        }

    }

    void RayHitSomething(Vector3 hitPosition, Vector3 hitNormal)
    {
        if (lineRenderer != null){
            lineRenderer.SetPosition(1, hitPosition);
        }
    }


    Ray UpdateCastRayIfPossible()
    {
        if (trackingSpace != null && activeController != OVRInput.Controller.None)
        {
            Quaternion orientation = OVRInput.GetLocalControllerRotation(activeController);
            Vector3 localStartPoint = OVRInput.GetLocalControllerPosition(activeController);

            Matrix4x4 localToWorld = trackingSpace.localToWorldMatrix;
            Vector3 worldStartPoint = localToWorld.MultiplyPoint(localStartPoint);
            Vector3 worldOrientation = localToWorld.MultiplyVector(orientation * Vector3.forward);

            if (GlobalVariable.MODE == "shape" || GlobalVariable.MODE == "drag")
            {
                position = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);
                if (position.y > 0)
                {

                    rayLengthUp = true;
                    rayLength += 100;
                }
                if (position.y < 0)
                {
                    rayLengthDown = true;
                    rayLength += 100;
                }
            }
            else
            {
                rayLength = 1000;
            }
            if (lineRenderer != null)
            {
                lineRenderer.SetPosition(0, worldStartPoint);
                lineRenderer.SetPosition(1, worldStartPoint + worldOrientation * rayLength);
            }

            if (inputModule != null)
            {
                inputModule.SelectionRay = new Ray(worldStartPoint, worldOrientation);
                return inputModule.SelectionRay;
            }
        }

        return new Ray();
    }

    void EraserInteraction(Ray pointer, RaycastHit hit){
        
        if (activeController != OVRInput.Controller.None){
            if (OVRInput.GetDown(joyPadClickButton, activeController)){
                selectedItem = hit.collider.gameObject;
                selectedItem.SetActive(false);
                  
            }  
        }        
    }

    void GrabInteraction(Ray pointer, RaycastHit hit){
        
        if (activeController != OVRInput.Controller.None){

            if (!OVRInput.Get(joyPadClickButton, activeController))
            {
               previousPosition = hit.point;
               distance = (hit.point -  pointer.origin).magnitude;
            }
            else
            {
                selectedItem = hit.collider.gameObject;
                selectedItem.transform.Translate(pointer.GetPoint(distance) - previousPosition);
                distance = (hit.point -  pointer.origin).magnitude;
                previousPosition = hit.point;

                position = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);
                if (position.y > 0.71 && (position.x < 0.7 || position.x > -0.7))
                {
                    selectedItem.transform.Translate(pointer.direction*2.0F);
                }
                if (position.y < -0.71 && (position.x < 0.7 || position.x > -0.7))
                {
                    selectedItem.transform.Translate(-pointer.direction*2.0F);
                }
                if (position.x < -0.71 && (position.y < 0.7 || position.y > -0.7))
                {
                    selectedItem.transform.localScale -= new Vector3(1.0F,1.0F,1.0F);
                }
                if (position.x > 0.71 && (position.y < 0.7 || position.y > -0.7))
                {
                    selectedItem.transform.localScale += new Vector3(1.0F,1.0F,1.0F);
                }
            }  
        }        
    }

    void CopyInteraction(Ray pointer, RaycastHit hit){
        
        if (activeController != OVRInput.Controller.None){

            if (!OVRInput.Get(joyPadClickButton, activeController))
            {
               previousPosition = hit.point;
               distance = (hit.point -  pointer.origin).magnitude;
            }
            else
            {
                selectedItem = hit.collider.gameObject;
                selectedItem.transform.Translate(pointer.GetPoint(distance) - previousPosition);
                distance = (hit.point -  pointer.origin).magnitude;
                previousPosition = hit.point;

                position = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);
                if (position.y > 0.71 && (position.x < 0.7 || position.x > -0.7))
                {
                    selectedItem.transform.Translate(pointer.direction*2.0F);
                }
                if (position.y < -0.71 && (position.x < 0.7 || position.x > -0.7))
                {
                    selectedItem.transform.Translate(-pointer.direction*2.0F);
                }
                if (position.x < -0.71 && (position.y < 0.7 || position.y > -0.7))
                {
                    selectedItem.transform.localScale -= new Vector3(1.0F,1.0F,1.0F);
                }
                if (position.x > 0.71 && (position.y < 0.7 || position.y > -0.7))
                {
                    selectedItem.transform.localScale += new Vector3(1.0F,1.0F,1.0F);
                }
            }  
        }        
    }

    void ColorInteraction (Ray pointer, RaycastHit hit, Color color){

        if (activeController != OVRInput.Controller.None)
        {
             if (OVRInput.GetDown(joyPadClickButton, activeController)){
                selectedItem = hit.collider.gameObject;
                selectedItem.GetComponent<Renderer>().material.color = color;
            }    
        }

    }

    void ShapeInteraction(Ray pointer){
        
    }

    void ProcessNonUIInteractions(Ray pointer)
    {
        RaycastHit hit;

        if (MODE == "eraser")
        {
            shapeindicator.SetActive(false);
            colorsphere.SetActive(false);
            if (Physics.Raycast(pointer, out hit, rayLength))
            {
                EraserInteraction(pointer, hit);
            }
        }

        if (MODE == "color")
        {
            shapeindicator.SetActive(false);
            colorsphere.SetActive(true);
            if (Physics.Raycast(pointer, out hit, rayLength))
            {
                selectedColor = ChangeColor.sColor;
                ColorInteraction(pointer, hit, selectedColor);
            }
        }

        

        if (MODE == "grab")
        {
            if (Physics.Raycast(pointer, out hit, rayLength))
            {
                GrabInteraction(pointer, hit);
            }
        }

        if (MODE == "copy")
        {
            if (Physics.Raycast(pointer, out hit, rayLength))
            {
                CopyInteraction(pointer, hit);
            }
        }


    }


    void Update()
   {
        selectionRay = UpdateCastRayIfPossible();

        if (interactWithNonUIObjects){
            ProcessNonUIInteractions(selectionRay);
        }
    }

}
