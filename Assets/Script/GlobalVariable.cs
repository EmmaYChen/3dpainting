using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    static public Ray selectionRay;
    public Color selectedColor;
    //public GameObject test; 
    public bool interactWithNonUIObjects = true;
    public float rayLength = 500;
    public Transform trackingSpace = null;
    public LineRenderer lineRenderer = null;
    public UnityEngine.EventSystems.OVRInputModule inputModule = null;
    public GameObject colorsphere;

    protected Transform lastHit = null;
    protected Transform triggerDown = null;

    protected OVRInput.Controller activeController = OVRInput.Controller.RTrackedRemote;
    public OVRInput.Button joyPadClickButton = OVRInput.Button.PrimaryIndexTrigger;

    static public string MODE;

    private GameObject selectedItem;


    // Use this for initialization
    void Start()
    {
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

    void ColorInteraction (Ray pointer, RaycastHit hit, Color color){

        if (activeController != OVRInput.Controller.None)
        {
             if (OVRInput.GetDown(joyPadClickButton, activeController)){
                selectedItem = hit.collider.gameObject;
                selectedItem.GetComponent<Renderer>().material.color = color;
            }    
        }

    }

    void ProcessNonUIInteractions(Ray pointer)
    {
        RaycastHit hit;
        if (Physics.Raycast(pointer, out hit, rayLength))
        {
            if (MODE == "eraser")
            {
                colorsphere.SetActive(false);
                EraserInteraction(pointer, hit);
            }

            if (MODE == "color"){
                colorsphere.SetActive(true);
                selectedColor = ChangeColor.sColor;
                ColorInteraction(pointer, hit, selectedColor);
            }
            if (MODE == "shape"){
                
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
