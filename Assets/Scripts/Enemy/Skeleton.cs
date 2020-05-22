using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        Health = base.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }

        Movement();

        Vector3 direction = player.transform.localPosition - transform.localPosition;
        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
        }

    }


    public int Health { get; set; }
    public void Damage(int damageAmount)
    {
        Health-=damageAmount;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);
        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
        
    }
}
