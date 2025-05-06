using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : BaseController
{
    private Camera camera;
    

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void Update()
    {
        base.Update();
        IsClick(); // 클릭 감지
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  // 이동 방향
        float vertical = Input.GetAxisRaw("Vertical");   //이동 방향 
        movementDirection = new Vector2(horizontal, vertical).normalized; // 속도 조절

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    public void IsClick()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);

            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag("Box"))
                {
                    SceneManager.LoadScene("Game"); // "Game" 씬으로 이동
                }
            }
        }
    }
}