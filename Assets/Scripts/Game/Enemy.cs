using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 1f;
    public int hp = 0;
    public int score = 0;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
        {
            target = go.transform;
        }
    }
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        if (target != null)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Projectile proj = collision.GetComponent<Projectile>();
            if (hp <= proj.bulletDamage)
            {
                GameManager.Instance.currentScore += score;
                Destroy(gameObject);
                
            }
            hp -= proj.bulletDamage;
            
            anim.SetBool("IsDamaged" ,true);
            StartCoroutine(AnimSetFalse());
        }
    }

    IEnumerator AnimSetFalse()
    {
        yield return new WaitForSeconds(0.3f); // 1초 기다리고
        anim.SetBool("IsDamaged", false);   // false로 다시 돌림
    }



}
