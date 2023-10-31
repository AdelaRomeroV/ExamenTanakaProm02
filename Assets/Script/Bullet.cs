using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    private Rigidbody2D rb;
    public float speedB;
    private Vector2 dire;

    // Update is called once per frame
    void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
       Destroy(gameObject, 2f);
    }

    public void direction (Vector2 vale)
    {  
        dire = vale;
    }

    void Update()
    {
        rb.velocity = (dire * speedB);
    }
}
