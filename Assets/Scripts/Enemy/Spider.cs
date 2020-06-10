using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{

    
    public GameObject acidEffectPrefab;
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

    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }

    public int Health { get; set; }
    public void Damage(int damageAmount)
    {
        if(isDead) return;
        Health--;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            SpawnDiamond();
        }
    }
}
