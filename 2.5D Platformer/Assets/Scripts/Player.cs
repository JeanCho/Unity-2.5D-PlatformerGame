using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _cotnroller;
    [SerializeField]
    private float _speed =5.0f;
    [SerializeField]
    private float _jumpSpeed = 3.0f;
    [SerializeField]
    private float _gravity =1.0f;
    private float _yVelocity;
    private Vector3 _moveDirection = Vector3.zero;
    private bool _DoubleJumped =true;
    private int _coinCollected = 0;
    [SerializeField]
    private int _lives = 3;
    private UIManager _uIManager;
    
    void Start()
    {
        _cotnroller = GetComponent<CharacterController>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>(); 
        if(_uIManager == null)
        {
            Debug.LogError("Can not locate UIMAnager to player");
        }
        _uIManager.UpdateLivesDisplay(_lives);
    }

    void Update()
    {
        MoveCharacter();

    }

    private void MoveCharacter()
    {
       
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        Vector3 Velocity = _moveDirection * _speed;
            _moveDirection *= _speed;

        if (_cotnroller.isGrounded)
        {
            _DoubleJumped = false;

            if (Input.GetButtonDown("Jump"))
            {
                _yVelocity = _jumpSpeed;
            }
        }
        else
        {

            if (Input.GetButtonDown("Jump") )
            {

                if(_DoubleJumped == false)
                {
                    _yVelocity = _jumpSpeed;
                    _DoubleJumped = true;
                }
                
            }
            _yVelocity -= _gravity * Time.deltaTime;

        }
        Velocity.y = _yVelocity;
        _cotnroller.Move(Velocity* Time.deltaTime);
    }

    public void CollectCoin()
    {
        _coinCollected++;
        _uIManager.UpdateCoinDisplay(_coinCollected);
    }

    public void LoseLife()
    {
        _lives--;
        _uIManager.UpdateLivesDisplay(_lives);
        if(_lives<1)
        {
            SceneManager.LoadScene(0);
        }
       
    }

    
}
