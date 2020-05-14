using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{

    private Vector3 _currentTarget;
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private SpriteRenderer _mossSprite;
    private void Start()
    {
    }

    private void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        
        Movement();
    }

    private void Movement()
    {
        if (_currentTarget == pointA.position)
        {
            _mossSprite.flipX = true;
        }
        else
        {
            _mossSprite.flipX = false;
        }
        
        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _anim.SetTrigger("Idle");            
        }

        transform.position = Vector3.MoveTowards(transform.position,
                _currentTarget, speed * Time.deltaTime);
    }
}
