using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float jumpForce;
    private Vector3 velocity = Vector3.zero;

    public bool isJumping = false;
    public bool isGrounded = false;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Animator animator;

    public SpriteRenderer spriteRenderer;



    void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
           
            isJumping = true;
        }

        MovePlayer(moveHorizontal);

        Flip(rb.linearVelocity.x);

        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        
        
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
