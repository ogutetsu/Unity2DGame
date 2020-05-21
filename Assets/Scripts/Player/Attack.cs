﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);

        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.Damage(1);
        }
        
    }
}
