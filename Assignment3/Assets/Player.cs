using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    public float speed = 5;
    CharacterController controller;
    float movement;
    public float gravity = 20; 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            movement = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
            movement = transform.TransformDirection(movement);
            movement = movement * speed;
            anim.SetFloat("Speed", movement);
        }
        //gravity
        movement.y = movement.y - (gravity * Time.deltaTime);
        controller.Move(movement * Time.deltaTime);
    }
}
