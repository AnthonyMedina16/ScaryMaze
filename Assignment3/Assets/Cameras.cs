using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public Camera Camera1; 
    public Camera Camera2;
    public Camera Camera3;
    public Camera Camera4;
    public Transform player;
    Transform angledCamM; 

    /* void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        Camera1.enabled = true;
        Camera2.enabled = false;
        Camera3.enabled = false;
        Camera4.enabled = false;
        angledCamM = Camera3.transform;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.position.x < 45 && player.position.x > 20)
        {
            Camera2.enabled = true;
            Camera1.enabled = false;
            Camera3.enabled = false;
            Camera4.enabled = false;
            Camera2.transform.LookAt(player);
        }
        else if (player.position.x < -5 && player.position.x > -30)
        {
            Camera4.enabled = true;
            Camera1.enabled = false;
            Camera3.enabled = false;
            Camera2.enabled = false;
            Camera4.transform.LookAt(player);
        }
        else if (player.position.x > -5 && player.position.x < 20)
        {
            Camera3.enabled = true;
            Camera1.enabled = false;
            Camera2.enabled = false;
            Camera4.enabled = false;
            angledCamM.position = new Vector3(player.position.x, angledCamM.position.y, angledCamM.position.z);
            //angledCamM.position.z = this.position.x;
        }
        else if (player.position.z > 45 && player.position.z < 70)
        {
            Camera1.enabled = true;
            Camera2.enabled = false;
            Camera3.enabled = false;
            Camera4.enabled = false;
        }
    }
}
