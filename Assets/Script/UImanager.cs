using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {
    
    public GameObject color_panel;

    // Use this for initialization
    void Start()
    {
        color_panel.gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){
            Debug.Log("color button click");
        }

        if (OVRInput.Get(OVRInput.Button.Two)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void ColorModeOn(){
        GlobalVariable.MODE = "color";
        color_panel.gameObject.SetActive(true);   
    }

    public void ShapeModeOn(){
        GlobalVariable.MODE = "shape";
        color_panel.gameObject.SetActive(false);  
       
    }

    public void EraseModeOn(){
        GlobalVariable.MODE = "eraser";
        color_panel.gameObject.SetActive(false);  
        
    }

}
