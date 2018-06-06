using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {
    
    public GameObject color_panel;
    public GameObject shape_panel;

    // Use this for initialization
    void Start()
    {
        color_panel.gameObject.SetActive(false);
        shape_panel.gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (OVRInput.Get(OVRInput.Button.Two)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void ColorModeOn(){
        GlobalVariable.MODE = "color";
        color_panel.gameObject.SetActive(true);   
        shape_panel.gameObject.SetActive(false);
    }

    public void ShapeModeOn(){
        GlobalVariable.MODE = "shape";
        color_panel.gameObject.SetActive(false);  
        shape_panel.gameObject.SetActive(true);
       
    }

    public void EraseModeOn(){
        GlobalVariable.MODE = "eraser";
        color_panel.gameObject.SetActive(false);  
        shape_panel.gameObject.SetActive(false);
        
    }

    public void GrabModeOn(){
        GlobalVariable.MODE = "grab";
        color_panel.gameObject.SetActive(false);  
        shape_panel.gameObject.SetActive(true);
        
    }

    public void CopyModeOn(){
        GlobalVariable.MODE = "copy";
        color_panel.gameObject.SetActive(false);  
        shape_panel.gameObject.SetActive(true);
        
    }

    public void ScaleModeOn(){
        GlobalVariable.MODE = "scale";
        color_panel.gameObject.SetActive(false);  
        shape_panel.gameObject.SetActive(true);
        
    }

    public void BrushModeOn()
    {
        GlobalVariable.MODE = "brush";
        color_panel.gameObject.SetActive(false);
        shape_panel.gameObject.SetActive(true);

    }

}
