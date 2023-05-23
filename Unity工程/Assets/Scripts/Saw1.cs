using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw1 : MonoBehaviour
{
    public float speed = 2;
    public float moveTime = 3;
    private bool directionRight = false;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (directionRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        timer += Time.deltaTime;
        if (timer > moveTime)
        {
            directionRight = !directionRight;
            timer = 0;
        }

    }
}
