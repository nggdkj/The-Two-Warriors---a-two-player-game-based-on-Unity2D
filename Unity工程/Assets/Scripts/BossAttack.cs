using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float speed;
    public float lifetime;
    private Transform Player1Transform;
    private Transform Player2Transform;
    static int bulletId = 0;
    public int id = 0;
    public GameObject Player;
    public GameObject Player2;


    // Start is called before the first frame update
    void Start()
    {
        bulletId++;
        id = bulletId;
        if(Player.activeSelf && Player2.activeSelf)
        {
            Player1Transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            Player2Transform = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
            Invoke("Destroybullet", lifetime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (id % 2 == 0)
        {
            if (Player1Transform != null)
            {
                float distance = (transform.position - Player1Transform.position).sqrMagnitude;
                transform.position = Vector2.MoveTowards(transform.position, Player1Transform.position, speed * Time.deltaTime);
            }
        }
        if (id % 2 == 1)
        {
            if (Player2Transform != null)
            {
                float distance = (transform.position - Player2Transform.position).sqrMagnitude;
                transform.position = Vector2.MoveTowards(transform.position, Player2Transform.position, speed * Time.deltaTime);
            }
        }
    }

    void Destroybullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            GameController.Instance.ShowGameOverPanel();
            other.gameObject.SetActive(false);
        }
    }
}
