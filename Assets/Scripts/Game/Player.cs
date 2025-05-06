using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseController
{
    

    public GameObject[] projectilePrefabs;
    public Transform firePoint;
    Animator anim;
    public int hp = 3;
    HPUI hpui;
    GameOverUI gameOverUI;
    protected override void Start()
    {
        base.Start();
        hpui = FindObjectOfType<HPUI>();
        //gameOverUI = GameObject.Find("GameOver").GetComponent<GameOverUI>();
        anim = GetComponentInChildren<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            Shoot();
        }

    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  // 이동 방향
        float vertical = Input.GetAxisRaw("Vertical");   //이동 방향 
        movementDirection = new Vector2(horizontal, vertical).normalized;
    }

    public void Shoot()
    {
        GameObject proj = Instantiate(projectilePrefabs[GameManager.Instance.level - 1], firePoint.position, firePoint.rotation);

        Projectile projectile = proj.GetComponent<Projectile>();

        projectile.rb.velocity = firePoint.right * projectile.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            hp--;
            hpui.DecreaseHp();
            anim.SetBool("IsDamaged", true);
            StartCoroutine(AnimSetFalse());
            if (hp <=0 )
            {
                Time.timeScale = 0f;
                //gameOverUI.gameObject.SetActive(true);
            }
            
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.currentScore++;
        }
        
    }

    IEnumerator AnimSetFalse()
    {
        yield return new WaitForSeconds(0.3f); // 1초 기다리고
        anim.SetBool("IsDamaged", false);   // false로 다시 돌림
    }


}
