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
    public GameOverUI gameOverUI;
    private float godtime = 1f;

    public AudioClip[] audioClip;
    protected override void Start()
    {
        base.Start();
        hpui = FindObjectOfType<HPUI>();
        anim = GetComponentInChildren<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            Shoot();
        }
        godtime -= Time.deltaTime;

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
            if (godtime <= 0)
            {
            hp--;
            hpui.DecreaseHp();
            if (audioClip != null)
            {
                SoundManager.PlayClip(audioClip[0]);
            }
            anim.SetBool("IsDamaged", true);
            StartCoroutine(AnimSetFalse());
            if (hp <=0 )
            {
                Time.timeScale = 0f;
                gameOverUI.gameObject.SetActive(true);
            }

            }
            godtime = 1f;

        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.currentScore++;
            if (audioClip != null)
            {
                SoundManager.PlayClip(audioClip[1]);
            }
        }
        
    }

    IEnumerator AnimSetFalse()
    {
        yield return new WaitForSeconds(0.3f); // 1초 기다리고
        anim.SetBool("IsDamaged", false);   // false로 다시 돌림
    }


}
