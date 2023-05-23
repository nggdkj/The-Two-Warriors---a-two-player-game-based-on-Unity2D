using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    public int damage;
    public float time;
    public float startTime;
    private Animator anim;
    private PolygonCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player2").GetComponent<Animator>();
        collider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            anim.SetBool("attack", true);
            StartCoroutine(StartAttack());
        }
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startTime);
        anim.SetBool("attack", false);
        yield return new WaitForSeconds(startTime);
        collider.enabled = true;
        StartCoroutine(diableAttack());
    }

    IEnumerator diableAttack()
    {
        yield return new WaitForSeconds(time);
        collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Boss"))
        {
            other.GetComponent<Boss>().TakeDamage(damage);
        }
    }
}
