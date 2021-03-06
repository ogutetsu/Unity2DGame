﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{

    public int diamonds;
    
    private Rigidbody2D _rigid;

    [SerializeField]
    private float _jumpforce = 5.0f;
    [SerializeField]
    private LayerMask _groundLayer;

    private bool _resetJump = false;
    private bool _grounded = false;

    [SerializeField]
    private float _speed = 5.0f;

    private PlayerAnimation _playerAnimation;

    private SpriteRenderer _sprite;

    [SerializeField]
    private SpriteRenderer _swordArcSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        var move = Movement();

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
        
        _playerAnimation.Move(move);

        if (CrossPlatformInputManager.GetButtonDown("A_Button") && IsGrounded() == true)
        {
            _playerAnimation.Attack();
        }
        
    }

   

    private float Movement()
    {
        float move;
#if UNITY_EDITOR
        move = CrossPlatformInputManager.GetAxis("Horizontal");
        if(move == 0.0f) move = Input.GetAxis("Horizontal");
#else
        move = CrossPlatformInputManager.GetAxis("Horizontal");
#endif
        _grounded = IsGrounded();
        Flip(move);

        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) && _grounded)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpforce);
            StartCoroutine(ResetJumpNeeded());
            _playerAnimation.Jump(true);
        }

        return move;
    }

    private void Flip(float move)
    {
        if (move > 0)
        {
            _sprite.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;
            Vector3 swordArcPos = _swordArcSprite.transform.localPosition;
            swordArcPos.x = 1.01f;
            _swordArcSprite.transform.localPosition = swordArcPos;
        }
        else if (move < 0)
        {
            _sprite.flipX = true;
            
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;
            Vector3 swordArcPos = _swordArcSprite.transform.localPosition;
            swordArcPos.x = -1.01f;
            _swordArcSprite.transform.localPosition = swordArcPos;
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer.value);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                _playerAnimation.Jump(false);
                return true;
            }
        }
        return false;
    }
    
    IEnumerator ResetJumpNeeded()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public int Health { get; set; }
    public void Damage(int damageAmount)
    {
        if (Health < 1)
        {
            return;
        }
        Health--;
        UIManager.Instance.UpdateLives(Health);
        if (Health < 1)
        {
            _playerAnimation.Death();
        }
    }

    public void AddGems(int amount)
    {
        diamonds += amount;
        UIManager.Instance.UpdateGemCount(diamonds);
    }
    
}
