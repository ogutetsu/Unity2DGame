﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    
    void Start()
    {
        base.Start();
        Health = base.health;
    }

    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();
    }

    public int Health { get; set; }
    public void Damage(int damageAmount)
    {
        
    }
}
