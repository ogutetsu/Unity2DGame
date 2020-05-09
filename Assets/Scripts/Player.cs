using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;

    [SerializeField]
    private float _jumpforce = 5.0f;
    [SerializeField]
    private LayerMask _groundLayer;

    private bool _resetJump = false;

    [SerializeField]
    private float _speed = 5.0f;

    private PlayerAnimation _playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        var move = Movement();

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
        
        _playerAnimation.Move(move);
        
    }

   

    private float Movement()
    {
        float move = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpforce);
            StartCoroutine(ResetJumpNeeded());
        }

        return move;
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer.value);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
                return true;
        }
        return false;
    }
    
    IEnumerator ResetJumpNeeded()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
    
}
