using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {
    private GameObject color_panel;

    // Use this for initialization
    void Start()
    {
        color_panel = GameObject.FindGameObjectWithTag("colorpanel");
        color_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Button color_button = gameObject.GetComponent<Button>();
        //if(color_button.onClick()){
            
        //}
        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        //{
        //    Debug.Log("color button click");

        //}
    }

    public void Color_panel_showup()
    {
        color_panel.SetActive(true);   
    }
}
