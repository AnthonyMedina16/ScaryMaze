using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    //private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        //animator.SetBool("Open", true);
        transform.rotation = Quaternion.Euler(0, -90, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        //animator.SetBool("Close", true);
        //transform.Rotate(new Vector3(0, -90, 0));
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
