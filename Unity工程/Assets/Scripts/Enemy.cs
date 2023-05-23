using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2;
    public float moveTime = 3;
    private bool directionRight = true;
    private float timer;

    private Rigidbody2D myRigidbody; 
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(directionRight)
        {
            myRigidbody.transform.eulerAngles = new Vector3(0f, 0f ,0f);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            myRigidbody.transform.eulerAngles = new Vector3(0f, 180f ,0f);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        timer += Time.deltaTime;
        if(timer>moveTime)
        {
            directionRight = !directionRight;
            timer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            GameController.Instance.ShowGameOverPanel();
            Destroy(other.gameObject);
        }
    }

}