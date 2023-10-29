using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveInput;
    public float moveSpeed=3.5f;
    public float jumpForce;
    public Rigidbody2D rb;
    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpTime;
    [SerializeField]bool isFacingRight;
    [SerializeField]private float fallFactor;
    [SerializeField] private float shortJumpFactor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();
        GroundCheck();
        Jump();
        BetterJump();
    }
    private void Move()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, 0);
    }
    private void Flip()
    {
        if (moveInput > 0)
        {
            isFacingRight = true;
            transform.rotation = Quaternion.identity;
        }
        if(moveInput < 0) 
        {
            isFacingRight= false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (isFacingRight)
        {
            
        }
        if (!isFacingRight)
        {
            
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        }
    }
    private void BetterJump()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallFactor * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * shortJumpFactor * Time.deltaTime;
        }
    }
    private void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(feetPos.position, checkRadius);
    }
}
