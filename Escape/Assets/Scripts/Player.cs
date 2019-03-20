using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    CharacterController controller;
    private GameObject player;
    public GameObject monster, monster2, monster3, monster4, monster5, monster6, monster7, monster8, monster9;
    public Camera blackCamera;
    public Camera mainCamera;
    public float speed = 5;
    public AudioClip key;
    public AudioSource keySource;
    public AudioClip kill;
    public AudioSource killSource;
    public AudioClip sense;
    public AudioSource senseSource;
    public AudioClip chase;
    public AudioSource chaseSource;
    public AudioClip ambiance;
    public AudioSource ambianceSource;
    private bool showText1 = false, showText2 = false, showText3 = false;
    Vector3 movement;
    public float gravity = 20;
    //public GameObject Door;
    //public Animator anim;
    public float rotationSpeed = 1;
    private bool showLabel = true;
    public bool open, open2, open3, open4 = false;
    private bool End = false;
    private bool dead = false;
 
    void Start()
    {
        blackCamera.enabled = false;
        mainCamera.enabled = true;
        player = GameObject.Find("player");
        controller = GetComponent<CharacterController>();
        Invoke("ToggleLabel", 10);
        keySource.clip = key;
        killSource.clip = kill;
        senseSource.clip = sense;
        chaseSource.clip = chase;
        ambianceSource.clip = ambiance;
        ambianceSource.Play();
    }

    void Update()
    {
        if(dead || End)
        {
            blackCamera.enabled = true;
            mainCamera.enabled = false;
            if (Input.GetKeyDown(KeyCode.R))
            {
                Scene loadedLevel = SceneManager.GetActiveScene();
                SceneManager.LoadScene(loadedLevel.buildIndex);
            }
        }
        else
        {
            if (controller.isGrounded)
            {
                movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                movement = transform.TransformDirection(movement);
                movement = movement * speed;
                if (Input.GetKey(KeyCode.Space))
                {
                    movement *= 2;
                }
            }
            //gravity
            movement.y = movement.y - (gravity * Time.deltaTime);
            controller.Move(movement * Time.deltaTime);
            checkChase();
            if (player.transform.position.z >= 520)
            {
                End = true;
                endGame();
            }
        }
    }
    public void ToggleLabel()
    {
        showLabel = !showLabel;
    }
    public void ToggleText1()
    {
        showText1 = !showText1;
    }
    public void ToggleText2()
    {
        showText2 = !showText2;
    }
    public void ToggleText3()
    {
        showText3 = !showText3;
    }
    public void checkChase()
    {
        float distance = Vector3.Distance(player.transform.position, monster.transform.position);
        float distance2 = Vector3.Distance(player.transform.position, monster2.transform.position);
        float distance3 = Vector3.Distance(player.transform.position, monster3.transform.position);
        float distance4 = Vector3.Distance(player.transform.position, monster4.transform.position);
        float distance5 = Vector3.Distance(player.transform.position, monster5.transform.position);
        float distance6 = Vector3.Distance(player.transform.position, monster6.transform.position);
        float distance7 = Vector3.Distance(player.transform.position, monster7.transform.position);
        float distance8 = Vector3.Distance(player.transform.position, monster8.transform.position);
        float distance9 = Vector3.Distance(player.transform.position, monster9.transform.position);
        if (distance <= 30f)
        {
            //print(!chaseSource.isPlaying);
            if (!chaseSource.isPlaying)
            {
                ambianceSource.Stop();
                chaseSource.Play();
            }
        }
        else if (distance2 <= 30f)
        {
            //print(!chaseSource.isPlaying);
            if (!chaseSource.isPlaying)
            {
                ambianceSource.Stop();
                chaseSource.Play();
            }
        }
        else if (distance3 <= 30f)
        {
            //print(!chaseSource.isPlaying);
            if (!chaseSource.isPlaying)
            {
                ambianceSource.Stop();
                chaseSource.Play();
            }
        }
        else if (distance4 <= 30f)
        {
            //print(!chaseSource.isPlaying);
            if (!chaseSource.isPlaying)
            {
                ambianceSource.Stop();
                chaseSource.Play();
            }
        }
        else if (distance5 <= 30f)
        {
            //print(!chaseSource.isPlaying);
            if (!chaseSource.isPlaying)
            {
                ambianceSource.Stop();
                chaseSource.Play();
            }
            print(chaseSource.isPlaying);
        }
        else if (distance6 <= 30f)
        {
            //print(!chaseSource.isPlaying);
            if (!chaseSource.isPlaying)
            {
                ambianceSource.Stop();
                chaseSource.Play();
            }
        }
        else if (distance7 <= 30f)
        {
           // print(!chaseSource.isPlaying);
            if (!chaseSource.isPlaying)
            {
                ambianceSource.Stop();
                chaseSource.Play();
            }
        }
        else if (distance8 <= 30f)
        {
            //print(!chaseSource.isPlaying);
            if (!chaseSource.isPlaying)
            {
                ambianceSource.Stop();
                chaseSource.Play();
            }
        }
        else if(distance9 <= 30f)
        {
            if (!chaseSource.isPlaying)
            {
                ambianceSource.Stop();
                chaseSource.Play();
            }
        }
        else
        {
            if (!ambianceSource.isPlaying)
            {
                chaseSource.Stop();
                ambianceSource.Play();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            keySource.Play();
            showText1 = !showText1;
            Invoke("ToggleText1", 5);
            other.gameObject.SetActive(false);
            open = true;
        }
        if (other.gameObject.CompareTag("Pick Up2"))
        {
            keySource.Play();
            showText2 = !showText2;
            Invoke("ToggleText2", 5);
            other.gameObject.SetActive(false);
            open2 = true;
        }
        if (other.gameObject.CompareTag("Pick Up3"))
        {
            keySource.Play();
            other.gameObject.SetActive(false);
            open3 = true;
            if (open3 && open4)
            {
                showText3 = !showText3;
                Invoke("ToggleText3", 5);
            }
        }
        if (other.gameObject.CompareTag("Pick Up4"))
        {
            keySource.Play();
            other.gameObject.SetActive(false);
            open4 = true;
            if (open3 && open4)
            {
                showText3 = !showText3;
                Invoke("ToggleText3", 5);
            }
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            killSource.Play();
            died();
        }
        if(other.gameObject.name == "lineofsight")
        {
            if(!senseSource.isPlaying)
            {
                senseSource.Play();

            }
        }
    }
    public void endGame()
    {
        //end the game
        End = true;
    }
    public void died()
    {
        dead = true;
        endGame();
    }
    public void OnGUI()
    {
        //win conditions
        var w = 200;
        var h = 100;
        if (showLabel)
        {
            GUI.skin.label.fontSize = 20;
            GUI.Label(new Rect(5, 5, w, h), "Find the key to open the doors and escape!");
        }
        w = 400;
        h = 200;
        if (dead == true)
        {
            GUI.skin.label.fontSize = 50;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, w, h), "You Died!");
        }
        //beat the game
        if (End == true && !dead)
        {
            GUI.skin.label.fontSize = 50;
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, w, h), "You Escaped!");
        }
        if (End)
        {
            GUI.skin.label.fontSize = 20;
            GUI.Label(new Rect(Screen.width/2 - 75, Screen.height/2 + 50, w, h), "Press R to restart");
        }
        if (showText1)
        {
            GUI.skin.label.fontSize = 30;
            GUI.Label(new Rect(Screen.width / 2 - 175, Screen.height / 2 - 75, w, h), "Doors in this area are open!");
        }
        if (showText2)
        {
            GUI.skin.label.fontSize = 30;
            GUI.Label(new Rect(Screen.width / 2 - 175, Screen.height / 2 - 75, w, h), "Doors in this area are open!");
        }
        if (showText3)
        {
            GUI.skin.label.fontSize = 30;
            GUI.Label(new Rect(Screen.width / 2 - 175, Screen.height / 2 - 75, w, h), "The exit is now open!");
        }
    }
}
