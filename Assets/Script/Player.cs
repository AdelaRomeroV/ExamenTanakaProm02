using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed;
    private Rigidbody2D rb2D;
    private Vector2 dir;

    [Header("Vida")]
    float life = 3;

    [Header("Disparo")]
    public GameObject Bullet;
    public GameObject Ulti;
    public float speedB;
    private float timeShooter;
    private float shooterleytimer;



    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Mov();
        shooter();
        Timer();
    }

    void Mov()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0 ) 
        {
            dir = new Vector2 (horizontal, vertical);
        }

        rb2D.velocity = new Vector2 (horizontal,vertical) * speed;

    }
    void Timer()
    {
        timeShooter += Time.deltaTime;
    }

    void shooter()
    { 
        if (Input.GetKeyDown(KeyCode.Space) && timeShooter >= shooterleytimer) 
        {
            GameObject obj = Instantiate(Bullet);
            obj.transform.position = transform.position;
            timeShooter = 0;
            obj.GetComponent<Bullet>().direction(dir);
        }

        if (Input.GetKeyDown(KeyCode.E) && timeShooter >= shooterleytimer)
        {
            GameObject obj = Instantiate(Ulti);
            obj.transform.position = transform.position;
            timeShooter = 0;
            obj.GetComponent<Bullet>().direction(dir);
        }
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            life-= collision.gameObject.GetComponent<Damage>().damage;

            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }

        /* if(collision.gameObject.CompareTag("BulletEnemy"))
        {
            life--;
            if(life <= 0)
            {
                Destroy(gameObject);
            }
        }*/

        if(collision.gameObject.CompareTag("lifeItems"))
        {
            life += collision.gameObject.GetComponent<lifeItem>().lifemax;
        }
    }
}
