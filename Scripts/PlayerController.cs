using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private LayerCollisionChecker _groundChecker;
    [SerializeField] private LayerCollisionChecker _platformChecker;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private bool _isGrounded;
    private bool _canDoubleJump;

    private int _runAnimation = Animator.StringToHash("isRunning");
    private int _jumpAnimation = Animator.StringToHash("isGrounded");
    private int _fallSpeed = Animator.StringToHash("fallSpeed");
    private int _doubleJumpAnimation = Animator.StringToHash("isDoubleJumped");

    private bool _isRunningLeft;
    private bool _isRunningRight;
    private bool _isRunning;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _isRunningLeft = Input.GetKey(KeyCode.A);
        _isRunningRight = Input.GetKey(KeyCode.D);
        _isRunning = _isRunningLeft ^ _isRunningRight;

        if (_isRunning)
        {
            if (_isRunningRight)
            {
                transform.Translate(transform.right * _speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-transform.right * _speed * Time.deltaTime);
            }

            _spriteRenderer.flipX = _isRunningLeft;
        }

        _animator.SetBool(_doubleJumpAnimation, _canDoubleJump == false);
        _animator.SetBool(_runAnimation, _isRunning);
        _animator.SetBool(_jumpAnimation, _isGrounded);
        _animator.SetFloat(_fallSpeed, _rigidbody2D.velocity.y);
    }

    private void Update()
    {
        _isGrounded = _groundChecker.IsCollisioned || _platformChecker.IsCollisioned;

        if (_isGrounded)
            _canDoubleJump = true;

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_canDoubleJump || _isGrounded)
            {
                _canDoubleJump = _isGrounded;

                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
                _rigidbody2D.AddForce(Vector2.up * _jumpPower);
            }
        }
    }
}
