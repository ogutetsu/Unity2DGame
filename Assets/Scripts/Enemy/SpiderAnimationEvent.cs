﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{

    [SerializeField]
    private Spider _spider;
    
    private void Start()
    {
        
    }

    public void Fire()
    {
        _spider.Attack();
    }
}
