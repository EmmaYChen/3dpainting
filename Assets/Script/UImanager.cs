using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){
            Debug.Log("color button click");

        }

        if (OVRInput.Get(OVRInput.Button.Two))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void ColorModeOn(){
        GlobalVariable.MODE = "color";
        color_panel.gameObject.SetActive(true);   
    }

    public void ShapeModeOn(){
        GlobalVariable.MODE = "shape";
        test.gameObject.SetActive(true);
    }

    public void EraseModeOn(){
        GlobalVariable.MODE = "eraser";
        
    }

}
