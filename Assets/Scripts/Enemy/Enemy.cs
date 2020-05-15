using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{

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
    
    
    public virtual void Movement()
    {
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

        transform.position = Vector3.MoveTowards(transform.position,
            currentTarget, speed * Time.deltaTime);
        
    }
    

}
