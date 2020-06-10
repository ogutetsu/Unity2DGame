using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected GameObject DiamondPrefab;

    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;

    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    [FormerlySerializedAs("_anim")] [SerializeField]
    protected Animator anim;
    [FormerlySerializedAs("_sprite")] [SerializeField]
    protected SpriteRenderer sprite;

    protected bool isDead = false;
    
    protected bool isHit = false;

    protected Player player;

    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Movement()
    {
        if (isDead) return;
        
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");            
        }

        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                currentTarget, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if (distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
        
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

    protected void SpawnDiamond()
    {
        GameObject diamond = Instantiate(DiamondPrefab, transform.position, Quaternion.identity) as GameObject;
        diamond.GetComponent<Diamond>().gems = gems;
    }
    

}
