using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletEnemy;
    [SerializeField] private Transform shootcontroller;
    private float firerate = 1.0f;
    private float nextfiretime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (nextfiretime < Time.time)
        {
            Instantiate(bulletEnemy, shootcontroller.transform.position, Quaternion.identity);
            nextfiretime = Time.time + firerate;

        }

    }
}
