using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;

    [SerializeField] private float MovementSpeed = 20f;
    [SerializeField] private float JumpForce = 70f;
    [SerializeField] private float GravityROA = 3.5f;

    private Rigidbody2D _rigidBody;
    private Collider2D _collider;
    private bool isJumping = false;
    private bool isGrounded = false;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {

        _rigidBody.freezeRotation = true;
        isGrounded = IsGrounded();


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var movement = horizontalInput * MovementSpeed;

      
        if (horizontalInput != 0)
        {
            _rigidBody.velocity = new Vector2(movement, _rigidBody.velocity.y);
        }    

        else if (horizontalInput == 0 && isGrounded)
        {
            _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
        }

        Flip();

        if (isJumping == true)
        {
            
            _rigidBody.velocity = new Vector2(movement, Vector2.up.y * JumpForce);
          
            isJumping = false;
        }
        if (isGrounded == false)
        {
            float stopX = horizontalInput == 0 ? -(_rigidBody.velocity.x) : 0;
            _rigidBody.AddForce(new Vector2(stopX, Vector2.down.y * GravityROA), ForceMode2D.Impulse);

        }

    }

    private bool IsGrounded()
    {
        float extraHeightText = .05f;

        RaycastHit2D rayCastHitLeft = Physics2D.Raycast(_collider.bounds.center - new Vector3(_collider.bounds.extents.x, 0, 0), Vector2.down, _collider.bounds.extents.y + extraHeightText, groundLayerMask);
        RaycastHit2D rayCastHitRight = Physics2D.Raycast(_collider.bounds.center + new Vector3(_collider.bounds.extents.x, 0, 0), Vector2.down, _collider.bounds.extents.y + extraHeightText, groundLayerMask);

        return rayCastHitLeft.collider != null || rayCastHitRight.collider != null;
    }

    private void Flip()
    {
        if(_rigidBody.velocity.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (_rigidBody.velocity.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }
}
