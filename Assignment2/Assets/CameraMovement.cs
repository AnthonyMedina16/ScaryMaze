using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;
    public Camera FPC, TPC;
    public bool camSwitch = false;

    private void Start()
    {
    }
    void OnGUI()
    {
        if(GUI.Button(new Rect(50, 300, 100, 75), "1P View"))
        {
            camSwitch = true;
            FPC.gameObject.SetActive(camSwitch);
            TPC.gameObject.SetActive(!camSwitch);
        }
        if (GUI.Button(new Rect(650, 300, 100, 75), "3P View"))
        {
            camSwitch = false;
            FPC.gameObject.SetActive(camSwitch);
            TPC.gameObject.SetActive(!camSwitch);
        }
    }
}
