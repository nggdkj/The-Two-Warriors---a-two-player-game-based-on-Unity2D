using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private float x;
    private float y;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rigidbody2D.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            _animator.SetBool("run", true);
            _rigidbody2D.transform.Translate(Vector3.right * speed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rigidbody2D.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            _animator.SetBool("run", true);
            _rigidbody2D.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            _animator.SetBool("run", false);
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
            Flag.pan.Judge2();
            Flag.pan.Judge();
        }
    }
}
