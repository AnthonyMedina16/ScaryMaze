using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float speed = 10;
    public GameObject camera1;
    public GameObject camera2;
    public Text countText;
    float gravity = 5;
    float jumpStrength = 20;
    CharacterController controller;
    Vector3 movement;
    private int count;
    //private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        count = 0;
        countText.text = "Count: "+ count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                movement += Vector3.up * jumpStrength;
            }
        }
        else
        {
            movement += new Vector3(0, -gravity, 0);
        }
            
        // float moveHorizontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");

        // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        controller.Move(movement*Time.deltaTime*speed);
        //rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            countText.text = "Count:" + count.ToString();

        }
        //Destroy(other.gameObject);
    }
}
