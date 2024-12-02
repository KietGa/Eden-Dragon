using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("Jumping")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    public Animator anim;
    public Rigidbody2D rb;
    private float direction;
    private BoxCollider2D boxCollider;
    public bool interact = true;
    private int extraJump;
    private int scene;
    private enum Action { idle, walk, jump }

    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        if (scene == 3 || scene == 4 || scene == 5)
        {
            extraJump = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Action action;
        direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(direction * moveSpeed, rb.velocity.y);

        if (IsGrounded() && (scene == 3 || scene == 4 || scene == 5))
        {
            extraJump = 1;
        }

        if (Input.GetButtonDown("Vertical") && IsGrounded() && interact)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight);
        }
        else if (Input.GetButtonDown("Vertical") && extraJump > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight);
            extraJump = 0;
        }

        if (direction > 0.01f && interact)
        {
            transform.localScale = Vector3.one;
            action = Action.walk;
        }
        else if (direction < -0.01f && interact)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            action = Action.walk;
        }
        else 
        {
            action = Action.idle;
        }

        if (rb.velocity.y > 0.01f || rb.velocity.y < -0.01f && interact)
        {
            action = Action.jump;
        }

        anim.SetInteger("action", (int)action);
    }

    private bool IsGrounded()
    {
        RaycastHit2D grounded = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return grounded.collider != null;
    }

    private bool IsWall()
    {
        RaycastHit2D walled = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return walled.collider != null;
    }

    public bool CanAttack()
    {
        return direction == 0 && IsGrounded() && !IsWall();
    }
}
