using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    Animator anim;
    public bool Open1;
    public bool Open2;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("open", false);
    }

    void Update()
    {
        Open1 = GameObject.FindWithTag("Player").GetComponent<Player>().open3;
        Open2 = GameObject.FindWithTag("Player").GetComponent<Player>().open4;
        if (Open1 == true && Open2 == true)
        {
            anim.SetBool("open", true);
        }
    }
}
