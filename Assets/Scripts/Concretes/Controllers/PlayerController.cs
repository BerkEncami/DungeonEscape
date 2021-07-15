using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,IEntityController
{
    [SerializeField]
    float moveSpeed=3f;
    float _horizontal;

    bool isJump = false;
    Jump jump;
     
  
    
    IAnimation _animation;
    IPlayerInput input;
    IMover mover;
    IFlip flip;
    IOnGround _onGround;
    IHealth _playerHealth;


    

    private void Awake()
    {
        _onGround = GetComponent<IOnGround>();
        jump = new Jump(GetComponent<Rigidbody2D>());
        input = new Mobile_Input();
        mover = new Mover(this,moveSpeed);
        _animation = new PlayerAnimations(GetComponent<Animator>());
        flip = new Flip(this);
        _playerHealth = GetComponent<IHealth>();
    }

    private void OnEnable()
    {
        _playerHealth.OnDead += _animation.DeadAnimation;
    }
    private void Start()
    {
        GameOver gameOver = FindObjectOfType<GameOver>();
        gameOver.SetPlayerHealth(_playerHealth);
    }

    private void Update()
    {
        if (_playerHealth.IsDead) return;
        _horizontal = input.Horizontal;

        if (input.JumpButtonDown && _onGround.IsGround)
        {
            isJump = true;
            
        }

        if (input.AttackButtonDown)
        {
            Debug.Log("attack");
            _animation.AttackAnimation();
            return;
        }

        _animation.JumpAnimation(!_onGround.IsGround);
        _animation.MoveAnimation(_horizontal);

    }
    private void FixedUpdate()
    {
        flip.FlipCharacter(_horizontal);
        mover.Tick(_horizontal);
       
        if (isJump && _onGround.IsGround)
        {
            jump.TickWithFixedUpdate();
            isJump = false;
        }
      
        
    }
}
