using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {
    private GameObject color_panel;
    public GameObject test;

    // Use this for initialization
    void Start()
    {
        color_panel = GameObject.FindGameObjectWithTag("colorpanel");
        color_panel.gameObject.SetActive(false);
        test.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        //Button color_button = gameObject.GetComponent<Button>();
        //if(color_button.onClick()){
            
        //}
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("color button click");

        }
    }

    public void Color_panel_showup()
    {
        color_panel.gameObject.SetActive(true);   
         
    }

    public void Shapes_panel_showup()
    {
        test.gameObject.SetActive(true);
    }
}
