using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;

    public GameObject fireball;
    public GameObject mouth;
    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private BoxCollider2D myFeet;
    private bool isGround;

    private float time;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        Attack();
        CheckGrounded();
        SwitchAnimation();
    }

    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) || myFeet.IsTouchingLayers(LayerMask.GetMask("Bound"));
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.transform.eulerAngles = new Vector3(0f, 180f ,0f);
            myAnim.SetBool("run", true);
            myRigidbody.transform.Translate(Vector3.right * runSpeed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.transform.eulerAngles = new Vector3(0f, 0f ,0f);
            myAnim.SetBool("run", true);
            myRigidbody.transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
        }
        else
        {
            myAnim.SetBool("run", false);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.W) && isGround)
        {
            myAnim.SetBool("jump", true);
            Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
            myRigidbody.velocity = Vector2.up * jumpVel;
        }
        if (isGround)
        {
            myAnim.SetBool("jump", false);
        }
        else
        {
            myAnim.SetBool("jump", true);
        }
    }

    void Attack()
    {
        if (time <= 0)
        {
            if (Input.GetKey(KeyCode.F))
            {
                myAnim.SetBool("attack", true);
                Instantiate(fireball, mouth.transform.position, transform.rotation);
                time = startTime;
            }
        }
        else
        {
            time -= Time.deltaTime;
            myAnim.SetBool("attack", false);
        }
    }

    void SwitchAnimation()
    {
        myAnim.SetBool("idle", false);
        if (isGround)
        {
            myAnim.SetBool("jump", false);
            myAnim.SetBool("idle", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            GameController.Instance.ShowGameOverPanel();
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Saw")
        {
            GameController.Instance.ShowGameOverPanel();
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Goal")
        {
            Flag.pan.Judge1();
            Flag.pan.Judge();
        }
    }
}
