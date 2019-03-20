using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door2 : MonoBehaviour
{
    Animator anim;
    public bool Open;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("open", false);
    }

    void Update()
    {
        Open = GameObject.FindWithTag("Player").GetComponent<Player>().open2;
        if (Open == true)
        {
            anim.SetBool("open", true);
        }
    }
}
