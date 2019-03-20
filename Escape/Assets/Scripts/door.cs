using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
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
        Open = GameObject.FindWithTag("Player").GetComponent<Player>().open;
        if (Open == true)
        {
            anim.SetBool("open", true);
        }
    }
}
