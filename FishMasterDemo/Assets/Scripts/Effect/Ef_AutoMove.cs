﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_AutoMove : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 Dir = Vector3.right;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Dir*speed*Time.deltaTime);
    }
}
