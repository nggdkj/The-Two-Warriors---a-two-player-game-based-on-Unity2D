using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float speed = 2;
    public float moveTime = 3;
    private bool directionRight = true;
    private float timer;
    private float time;
    public float startTime;
    public int health = 100;
    public int damage;

    public GameObject banner;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject mouth;
    private Rigidbody2D myRigidbody; 
    private Animator myAnim;

    public Slider healthbar;
    //public Slider healthbar;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health;
        //healthbar.value = health;
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

        if (time <= 0)
        {
            if (true)
            {
                Instantiate(bullet1, mouth.transform.position, transform.rotation);
                Instantiate(bullet2, mouth.transform.position, transform.rotation);
                time = startTime;
            }
        }
        else
        {
            time -= Time.deltaTime;
        }

        if (health <= 0)
        {
            banner.SetActive(true);
            myAnim.SetTrigger("die");
            Invoke("Delaydie", 0.33f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameController.Instance.ShowGameOverPanel();
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health >= 1)
        {
            myAnim.SetTrigger("hit");
        }
        Invoke("Delayhit", 0.2f);
    }

    void Delayhit()
    {
        myAnim.SetBool("hit", false);
    }

    void Delaydie()
    {
        Destroy(gameObject);
    }
}