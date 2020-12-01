﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collision col;

    private float x, y, xRaw, yRaw;
    private Vector3 dir;

    public float moveSpeed;
    public float jumpForce;
    public float dashSpeed;
    public float slideSpeed;

    private bool canMove = true;
    private bool canDash;
    private bool wallJumped;
    private bool isDashing;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collision>();

        rb.gravityScale = 3;
    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        xRaw = Input.GetAxisRaw("Horizontal");
        yRaw= Input.GetAxisRaw("Vertical");

        dir = new Vector3(xRaw, yRaw);

        Walk(dir);

        if(Input.GetButton("Jump"))
        {
            if (col.onGround)
                Jump(Vector2.up);
            if (col.onWall && !col.onGround)
                WallJump();
        }

        if (Input.GetButtonDown("Dash") && canDash)
            if(x != 0 || y != 0)
                Dash(xRaw, yRaw);

        if (col.onGround && !isDashing)
        {
            slideSpeed = 1;
            canDash = true;
            wallJumped = false;
            GetComponent<BetterJumping>().enabled = true;
        }

        if (col.onWall && !wallJumped)
            WallSlide();

    }

    private void Walk(Vector3 dir)
    {
        if (!canMove)
            return;

        //if(wallJumped)
        //    rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * moveSpeed, rb.velocity.y)), 10f * Time.deltaTime);

        if (!isDashing)
            rb.velocity = new Vector2(dir.x * moveSpeed, rb.velocity.y);
    }

    private void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;
    }

    private void Dash(float x, float y)
    {
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(x, y);
        rb.velocity += dir.normalized * dashSpeed;
        canDash = false;

        StartCoroutine(DashControl());
    }

    private IEnumerator DashControl()
    {
        isDashing = true;
        GetComponent<BetterJumping>().enabled = false;
        rb.gravityScale = 0;

        yield return new WaitForSeconds(.075f);

        rb.velocity = Vector2.zero;
        isDashing = false;
        rb.gravityScale = 3;
        GetComponent<BetterJumping>().enabled = true;
    }

    private void WallJump()
    {
        if (!canMove)
            return;

        Vector2 wallDir = col.onRightWall ? Vector2.left : Vector2.right;
        wallJumped = true;

        StartCoroutine(DisableMovement(.1f));
        Jump(Vector2.up / 1.5f + wallDir / 1.5f);
        StartCoroutine(DisableMovement(2f));

    }

    private void WallSlide()
    {
        if (!canMove)
            return;

        slideSpeed += .1f;
        rb.velocity = new Vector2(rb.velocity.x, -slideSpeed);
    }

    private IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
}