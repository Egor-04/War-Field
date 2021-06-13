using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Values")]
    public float PlayerHP;
    [SerializeField] private float _crawlSpeed = 30f;
    [SerializeField] private float _crouchSpeed = 50f;
    [SerializeField] private float _speed = 80f;
    [SerializeField] private float _runSpeed = 100f;
    [SerializeField] private float _jumpForce = 30f;
    [SerializeField] private float _gravityScale = -200f;

    [Header("Controller")]
    [SerializeField] private CharacterController _characterController;

    [Header("Jump")]
    [SerializeField] float _radius;
    [SerializeField] Transform _sphereCheckTransform;
    [SerializeField] LayerMask _layerMask;

    [Header("Interpolation")]
    [SerializeField] private float _interpolationSpeed = 0.7f;

    [Header("Buttons")]
    public KeyCode ButtonRun = KeyCode.LeftShift;
    public KeyCode ButtonJump = KeyCode.Space;
    public KeyCode CrouchButton = KeyCode.C;
    public KeyCode CrawlButton = KeyCode.LeftControl;

    [Header("Gizmos Color")]
    [SerializeField] private float _red, _green, _blue;

    private Vector3 _moveDirection;
    private Vector3 _velocity;

    private float _chachedSpeed;

    private bool _isGrounded;
    private bool _isCrouchEnable;
    private bool _isCrawlEnable;

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
        CrawlPose();
        CrouchPose();
        Run();

        //Gravity
        _velocity.y += _gravityScale * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void Run()
    {
        if (Input.GetKey(ButtonRun) && !_isCrouchEnable && !_isCrawlEnable)
        {
            _speed = Mathf.Lerp(_speed, _runSpeed, _interpolationSpeed);
        }
        else if (!Input.GetKeyDown(ButtonRun) && !_isCrouchEnable && !_isCrawlEnable)
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

    private void CrouchPose()
    {
        if (Input.GetKeyDown(CrouchButton))
        {
            if (!_isCrouchEnable)
            {
                _speed = _crouchSpeed;
                transform.localScale = new Vector3(transform.localScale.x, 20f, transform.localScale.z);
                _isCrouchEnable = true;
                _isCrawlEnable = false;
            }
            else
            {
                _speed = _chachedSpeed;
                transform.localScale = new Vector3(transform.localScale.x, 30f, transform.localScale.z);
                _isCrouchEnable = false;
                _isCrawlEnable = false;
            }
        }
    }

    private void CrawlPose()
    {
        if (Input.GetKeyDown(CrawlButton))
        {
            if (!_isCrawlEnable)
            {
                _speed = _crawlSpeed;
                transform.localScale = new Vector3(transform.localScale.x, 10f, transform.localScale.z);
                _isCrouchEnable = false;
                _isCrawlEnable = true;
            }
            else
            {
                _speed = _chachedSpeed;
                transform.localScale = new Vector3(transform.localScale.x, 20f, transform.localScale.z);
                _isCrouchEnable = true;
                _isCrawlEnable = false;
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(ButtonJump) && !_isCrouchEnable && !_isCrawlEnable)
        {
            if (_isGrounded)
            {
                _velocity.y = Mathf.Sqrt(_jumpForce * -2 * _gravityScale);
            }
        }
        else if (Input.GetKeyDown(ButtonJump) && _isCrouchEnable)
        {
            _speed = _chachedSpeed;
            transform.localScale = new Vector3(transform.localScale.x, 30f, transform.localScale.z);
            _isCrouchEnable = false;
        }
        else if (Input.GetKeyDown(ButtonJump) && _isCrawlEnable)
        {
            _speed = _chachedSpeed;
            transform.localScale = new Vector3(transform.localScale.x, 20f, transform.localScale.z);
            _isCrawlEnable = false;
            _isCrouchEnable = true;
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