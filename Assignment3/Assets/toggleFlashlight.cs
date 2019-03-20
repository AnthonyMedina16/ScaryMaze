using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleFlashlight : MonoBehaviour
{
    private Light light;
    public bool ON = false;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        Debug.Log("Press F to toggle flashlight");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ON = !ON;
        }
        if(ON)
        {
            light.enabled = true;
        }
        else if(!ON)
        {
            light.enabled = false;
        }
    }
}
