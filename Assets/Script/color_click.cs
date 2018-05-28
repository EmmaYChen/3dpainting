using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class color_click : MonoBehaviour {

    public GameObject color_panel;
    public Button color_button;


	// Use this for initialization
	void Start () {

        color_panel.gameObject.SetActive(false);

		
	}

    // Update is called once per frame
    void Update()
    {
        Button btn = color_button.GetComponent<Button>();
        //if(btn.onClick())
        //{
        //    color_panel.gameObject.SetActive(true);
            
        //}// the finger has touched the HMD trackpad.
                                     //{
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("color button click");

        }
    }
}
