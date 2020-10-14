using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 3f;
    public float jumpforce = 400f;
    public float movX;
    public bool facingRight = true;
    private bool jumping = false;
    private Rigidbody2D rb;
    private Transform transform;
    private Animator anm;

    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        transform = GetComponent<Transform> ();
        anm = GetComponent<Animator> ();
    }

    void Update () {

    }
    void FixedUpdate () {
        move ();

    }

    void move () {
        var AbsVelY = Mathf.Abs (rb.velocity.y);
        jumping = AbsVelY >= 0.05;
        if (Input.GetKeyDown (KeyCode.Space) && !jumping) {
            rb.AddForce (new Vector2 (rb.velocity.x, jumpforce));
            anm.SetBool ("Jump", true);
        }else {
            anm.SetBool ("Jump", false);
        }
        movX = Input.GetAxis ("Horizontal");
        if (movX != 0) {
            anm.SetBool ("Walk", true);
            if (movX > 0 && !facingRight) {
                flip ();
            } else if (movX < 0 && facingRight) {
                flip ();
            }
        } else {
            anm.SetBool ("Walk", false);
        }

        rb.velocity = new Vector2 (movX * speed, rb.velocity.y);
    }
    void flip () {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
}