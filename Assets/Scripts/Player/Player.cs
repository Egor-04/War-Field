using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Values")]
    public float PlayerHP;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _runSpeed = 20f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _gravityScale = -9.81f;

    [Header("Controller")]
    [SerializeField] private CharacterController _characterController;

    [Header("Jump")]
    [SerializeField] float _radius;
    [SerializeField] Transform _sphereCheckTransform;
    [SerializeField] LayerMask _layerMask;

    [Header("Interpolation")]
    [SerializeField] private float _interpolationSpeed = 0.7f;

    [Header("Buttons")]
    public KeyCode _buttonRun = KeyCode.LeftShift;
    public KeyCode _buttonJump = KeyCode.Space;

    [Header("Gizmos Color")]
    [SerializeField] private float _red, _green, _blue;

    private Vector3 _moveDirection;
    private Vector3 _velocity;

    [SerializeField] private bool _isGrounded;
    private float _chachedSpeed;

    private void Start()
    {
        _chachedSpeed = _speed;
        _characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CheckGround();
        SoftFall();

        Jump();
        Movement();
        Run();

        //Gravity
        _velocity.y += _gravityScale * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void Run()
    {
        if (Input.GetKey(_buttonRun))
        {
            _speed = Mathf.Lerp(_speed, _runSpeed, _interpolationSpeed);
        }
        else
        {
            _speed = _chachedSpeed;
        }
    }

    private void Movement()
    {
        //Movement
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        _moveDirection = transform.forward * vertical + transform.right * horizontal;

        _characterController.Move(_moveDirection * _speed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(_buttonJump))
        {
            if (_isGrounded)
            {
                _velocity.y = Mathf.Sqrt(_jumpForce * -2 * _gravityScale);
            }
        }
    }

    private void SoftFall()
    {
        if (_isGrounded && _velocity.y < 0f)
        {
            _velocity.y = -20f;
        }
    }

    private void CheckGround()
    {
        _isGrounded = Physics.CheckSphere(_sphereCheckTransform.position, _radius, _layerMask);

        if (_isGrounded)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(_red, _green, _blue);
        Gizmos.DrawWireSphere(_sphereCheckTransform.position, _radius);
    }
}