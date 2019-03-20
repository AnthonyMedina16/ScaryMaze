﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPV : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + offset;
    }
}
