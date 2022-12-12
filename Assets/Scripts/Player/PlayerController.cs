using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] private Animator animator;
    float inputX;
    bool inputJump;

    [SerializeField] private float groundCheckLength = 1;
    [SerializeField] private LayerMask groundLayer;
    bool groundCheck;

    bool ladderCheck = false;

    AudioManager audioManager;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        audioManager = AudioManager.instance;
    }

    private void Update()
    {
        MovePlayer();

        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    private void MovePlayer()
    {
        if (ladderCheck == false) {
            inputX = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(inputX * playerSpeed, rb.velocity.y);

            if (Mathf.Abs(inputX) > 0)
                animator.SetBool("Run",true);
            else
                animator.SetBool("Run", false);

            
        }
        else
        {
            inputX = Input.GetAxisRaw("Horizontal");
            var inputY = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(inputX * playerSpeed, inputY * playerSpeed);
        }
    }

    private void Jump()
    {
        if (IsGrounded() && !ladderCheck) {
            audioManager.PlayAudio("jump");
            rb.AddForce(new Vector2(rb.velocity.x, jumpPower), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
           
    }

    private void FixedUpdate()
    {
        groundCheck = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLength, groundLayer);
    }

    private bool IsGrounded()
    {
        return groundCheck;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down * groundCheckLength, Color.yellow);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            rb.gravityScale = 0;
            rb.drag = 0;
            rb.angularDrag = 0;
            ladderCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            rb.gravityScale = 1;
            rb.drag = 1;
            rb.angularDrag = 1;
            ladderCheck = false;
        }
    }

}
