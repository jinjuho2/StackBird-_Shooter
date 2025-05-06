using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;


    public float speed = 5f;
    public float time = 5f;
    public int bulletDamage = 3;
    
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
