using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 0.25f;
    public float JumpForce = 2;

    private float lastPositionY;

    private bool isJumping;
    private bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;

    void Start()
    {
        this.rig = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        this.lastPositionY = transform.position.y;
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 moviment = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += moviment * Time.deltaTime * this.Speed;

        if (Input.GetAxis("Horizontal") > 0f) {
            if (!anim.GetBool("fall"))
                anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0f) {
            if (!anim.GetBool("fall"))
                anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") == 0f) {
            if (!anim.GetBool("fall"))
                anim.SetBool("run", false);
        }

        float currentPositionY = transform.position.y;
        if (currentPositionY < this.lastPositionY)
            anim.SetBool("fall", true);
        this.lastPositionY = transform.position.y;
    }

    void _Jump()
    {
        this.rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping) {
                this._Jump();
                anim.SetBool("jump", true);
                // doubleJump = true;
            }
            /*
            else {
                if (doubleJump)
                {
                    this._Jump();
                    doubleJump = false;
                }
            }
            */
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("jump", false);
            anim.SetBool("fall", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }
}
