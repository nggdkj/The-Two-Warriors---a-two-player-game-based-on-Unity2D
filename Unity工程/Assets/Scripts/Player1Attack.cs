using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Attack : MonoBehaviour
{
    public int damage;
    public float speed;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFireBall", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.y == 0f)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
    }

    void DestroyFireBall()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bound") || other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Boss"))
        {
            other.GetComponent<Boss>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
