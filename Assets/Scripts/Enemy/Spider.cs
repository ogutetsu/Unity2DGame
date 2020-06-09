using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{

    // Start is called before the first frame update
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

    public override void Movement()
    {
        //base.Movement();
    }


    public int Health { get; set; }
    public void Damage(int damageAmount)
    {
        throw new NotImplementedException();
    }
}
