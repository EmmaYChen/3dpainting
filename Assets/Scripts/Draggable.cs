using UnityEngine;

public class Draggable : MonoBehaviour
{
	public bool fixX;
	public bool fixY;
	public Transform thumb;
    public Transform minBound;
    //public GameObject test;


	bool dragging;
    private Ray ray;

    void Start(){
        //test.SetActive(false);
    }


	void Update()
    {
        ray = GlobalVariable.selectionRay;
        if (GlobalVariable.MODE == "color"){
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){
                dragging = false;
                RaycastHit hit;
                if (GetComponent<Collider>().Raycast(ray, out hit, 500)){
                    dragging = true;
                }
            }

            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) dragging = false;
            if (dragging && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                RaycastHit hit;
                if (GetComponent<Collider>().Raycast(ray, out hit, 500))
                {
                    dragging = true;
                    var point = hit.point;
                    SetThumbPosition(point);
                    SendMessage("OnDrag", Vector3.one - (thumb.localPosition - minBound.localPosition) / GetComponent<BoxCollider>().bounds.size.x);

                }

            }
            
        }

	}

	void SetDragPoint(Vector3 point)
	{
		point = (Vector3.one - point) * GetComponent<Collider>().bounds.size.x + GetComponent<Collider>().bounds.min;
		SetThumbPosition(point);
	}

	public void SetThumbPosition(Vector3 point)
	{
        Vector3 temp = thumb.localPosition;
        thumb.position = point;
        thumb.localPosition = new Vector3(fixX ? temp.x : thumb.localPosition.x, fixY ? temp.y : thumb.localPosition.y, thumb.localPosition.z - 1);
	}
}
