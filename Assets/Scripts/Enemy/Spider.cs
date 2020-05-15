using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        
        Movement();
    }

}
