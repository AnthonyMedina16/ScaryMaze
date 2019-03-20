using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulation : MonoBehaviour
{
    public int Shape = 1;
    public GameObject Sphere;
    public GameObject Cube;
    public GameObject Capsule;
    void OnGUI()
    {
        //Shape Manipulation
        if(GUI.Button(new Rect(50, 25, 100, 50), "Set to Cube") && (GameObject.Find("Sphere") || GameObject.Find("Capsule")))
        {
            GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Cube.AddComponent<Manipulation>();
            Cube.transform.position = this.transform.position;
            Cube.transform.rotation = this.transform.rotation;
            Cube.transform.localScale = this.transform.localScale;
            Cube.GetComponent<Renderer>().material.color = this.GetComponent<Renderer>().material.color;
            Destroy(this.GetComponent("Manipulation"));
            Destroy(this.gameObject);
        }
        else if(GUI.Button(new Rect(350, 25, 100, 50), "Set to Sphere") && (GameObject.Find("Cube") || GameObject.Find("Capsule")))
        {
            GameObject Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Sphere.AddComponent<Manipulation>();
            Sphere.transform.position = this.transform.position;
            Sphere.transform.rotation = this.transform.rotation;
            Sphere.transform.localScale = this.transform.localScale;
            Sphere.GetComponent<Renderer>().material.color = this.GetComponent<Renderer>().material.color;
            Destroy(this.GetComponent("Manipulation"));
            Destroy(this.gameObject);
        }
        else if (GUI.Button(new Rect(650, 25, 100, 50), "Set to Capsule") && (GameObject.Find("Cube") || GameObject.Find("Sphere")))
        {
            GameObject Capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            Capsule.AddComponent<Manipulation>();
            Capsule.transform.position = this.transform.position;
            Capsule.transform.rotation = this.transform.rotation;
            Capsule.transform.localScale = this.transform.localScale;
            Capsule.GetComponent<Renderer>().material.color = this.GetComponent<Renderer>().material.color;
            Destroy(this.GetComponent("Manipulation"));
            Destroy(this.gameObject);
        }

        //Save
        if (GUI.Button(new Rect(200, 400, 100, 50), "Save"))
        {
            if (GameObject.Find("Cube"))
            {
                Shape = 1;
            }
            else if (GameObject.Find("Sphere"))
            {
                Shape = 2;
            }
            else if (GameObject.Find("Capsule"))
            {
                Shape = 3;
            }

            PlayerPrefs.SetInt("SaveShape", Shape);
            PlayerPrefs.SetFloat("SaveX", transform.position.x);
            PlayerPrefs.SetFloat("SaveY", transform.position.y);
            PlayerPrefs.SetFloat("SaveX", transform.position.z);
            PlayerPrefs.SetFloat("SaveXR", transform.rotation.x);
            PlayerPrefs.SetFloat("SaveYR", transform.rotation.y);
            PlayerPrefs.SetFloat("SaveZR", transform.rotation.z);
            PlayerPrefs.SetFloat("SaveWR", transform.rotation.w);
            PlayerPrefs.SetFloat("SaveXS", transform.localScale.x);
            PlayerPrefs.SetFloat("SaveYS", transform.localScale.y);
            PlayerPrefs.SetFloat("SaveZS", transform.localScale.z);
            PlayerPrefs.SetFloat("SaveColorR", GetComponent<Renderer>().material.color.r);
            PlayerPrefs.SetFloat("SaveColorG", GetComponent<Renderer>().material.color.g);
            PlayerPrefs.SetFloat("SaveColorB", GetComponent<Renderer>().material.color.b);
        }
        //Load
        if (GUI.Button(new Rect(500, 400, 100, 50), "Load"))
        {
            Destroy(this.GetComponent("Manipulation"));
            Destroy(this.gameObject);
            Shape = PlayerPrefs.GetInt("SaveShape");
            if (Shape == 1)
            {
                GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Cube.transform.position = new Vector3(PlayerPrefs.GetFloat("SaveX"), PlayerPrefs.GetFloat("SaveY"), PlayerPrefs.GetFloat("SaveZ"));
                Cube.transform.rotation = new Quaternion(PlayerPrefs.GetFloat("SaveXR"), PlayerPrefs.GetFloat("SaveYR"), PlayerPrefs.GetFloat("SaveZR"), PlayerPrefs.GetFloat("SaveWR"));
                Cube.transform.localScale = new Vector3(PlayerPrefs.GetFloat("SaveXS"), PlayerPrefs.GetFloat("SaveYS"), PlayerPrefs.GetFloat("SaveZS"));
                Cube.GetComponent<Renderer>().material.color = new Color(PlayerPrefs.GetFloat("SaveColorR"), PlayerPrefs.GetFloat("SaveColorG"), PlayerPrefs.GetFloat("SaveColorB"));
                Cube.AddComponent<Manipulation>();
                Shape = 1;
            }
            else if (Shape == 2)
            {
                GameObject Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Sphere.transform.position = new Vector3(PlayerPrefs.GetFloat("SaveX"), PlayerPrefs.GetFloat("SaveY"), PlayerPrefs.GetFloat("SaveZ"));
                Sphere.transform.rotation = new Quaternion(PlayerPrefs.GetFloat("SaveXR"), PlayerPrefs.GetFloat("SaveYR"), PlayerPrefs.GetFloat("SaveZR"), PlayerPrefs.GetFloat("SaveWR"));
                Sphere.transform.localScale = new Vector3(PlayerPrefs.GetFloat("SaveXS"), PlayerPrefs.GetFloat("SaveYS"), PlayerPrefs.GetFloat("SaveZS"));
                Sphere.GetComponent<Renderer>().material.color = new Color(PlayerPrefs.GetFloat("SaveColorR"), PlayerPrefs.GetFloat("SaveColorG"), PlayerPrefs.GetFloat("SaveColorB"));
                Sphere.AddComponent<Manipulation>();
            }
            else if (Shape == 3)
            {
                GameObject Capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                Capsule.transform.position = new Vector3(PlayerPrefs.GetFloat("SaveX"), PlayerPrefs.GetFloat("SaveY"), PlayerPrefs.GetFloat("SaveZ"));
                Capsule.transform.rotation = new Quaternion(PlayerPrefs.GetFloat("SaveXR"), PlayerPrefs.GetFloat("SaveYR"), PlayerPrefs.GetFloat("SaveZR"), PlayerPrefs.GetFloat("SaveWR"));
                Capsule.transform.localScale = new Vector3(PlayerPrefs.GetFloat("SaveXS"), PlayerPrefs.GetFloat("SaveYS"), PlayerPrefs.GetFloat("SaveZS"));
                Capsule.GetComponent<Renderer>().material.color = new Color(PlayerPrefs.GetFloat("SaveColorR"), PlayerPrefs.GetFloat("SaveColorG"), PlayerPrefs.GetFloat("SaveColorB"));
                Capsule.AddComponent<Manipulation>();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press RGB to change colors, WASD to move, Q/E to rotate, and N/M to scale.");
    }

    // Update is called once per frame
    void Update()
    {
      //change colors
      if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
      if(Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
      if(Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }

        //movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, 1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -1));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1, 0, 0));
        }

        //Rotation
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(5, 0, 0));
        }

        //Scaling
        if(Input.GetKey(KeyCode.N))
        {
            transform.localScale += new Vector3(0.1F, 0, 0);
        }
        if(Input.GetKey(KeyCode.M))
        {
            transform.localScale -= new Vector3(0.1F, 0, 0);
        }
        
    }

}
