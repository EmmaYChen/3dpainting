using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {

    public Color color = Color.white;

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void OnColorChange(HSBColor selectedcolor)
    {
        if (GlobalVariable.MODE == "color")
        {
            this.color = selectedcolor.ToColor();
        }
    }
}
