using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    // Start is called before the first frame update
    void Start()
    {
        Health = base.health;
    }

    // Update is called once per frame
    void Update()
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
        Health-=damageAmount;
        anim.SetTrigger("Hit");
        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
        
    }
}
