using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_01 : MonoBehaviour
{
    [Header("Movimiento")]

    private Rigidbody2D rb2d;
    public float speed;
    public Vector2 dir;

    public int life;

    public float timer;
    public float maxTimer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Mov();
        ChangeDirection();
    }

    void ChangeDirection()
    {
        timer += Time.deltaTime;

        if (timer >= maxTimer)
        {
            dir *= -1;
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life--;

            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Mov()
    {
        rb2d.velocity = dir * speed;
    }
}
