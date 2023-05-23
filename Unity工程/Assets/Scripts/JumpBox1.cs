using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float JumpVelocity = 5f;
    public LayerMask mask;
    public float boxheight;

    private Vector2 playerSize;
    private Vector2 boxSize;

    private bool jumpRequest = false;
    private bool grounded = false;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        playerSize = GetComponent<SpriteRenderer>().bounds.size;
        boxSize = new Vector2(playerSize.x * 0.15f, boxheight);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && grounded)
        {
            jumpRequest = true;
        }
        if (grounded)
        {
            _animator.SetBool("jump", false);
        }
        else
        {
            _animator.SetBool("jump", true);
        }
    }

    private void FixedUpdate()
    {
        if (jumpRequest)
        {
            _rigidbody2D.AddForce(Vector2.up * JumpVelocity, ForceMode2D.Impulse);
            jumpRequest = false;
            grounded = false;
        }
        else
        {
            Vector2 boxCenter =(Vector2) transform.position + (Vector2.down * playerSize * 0.5f);

            if (Physics2D.OverlapBox(boxCenter, boxSize, 0, mask) != null)
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (grounded)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Vector2 boxCenter =(Vector2) transform.position + (Vector2.down * playerSize * 0.5f);
        Gizmos.DrawWireCube(boxCenter, boxSize);
    }
}
