using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletE : MonoBehaviour
{
    GameObject target;
    public float speed;
    private Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        if (target != null )
        {
            Vector2 movDir = (target.transform.position - transform.position).normalized * speed;
            rb2d.velocity = new Vector2(movDir.x, movDir.y);
        }

        else
        {
            gameObject.SetActive(false);    
        }
    }

    private void Update()
    {
        Destroy(gameObject, 5f);
    }
}
