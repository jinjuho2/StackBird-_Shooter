using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : BaseController
{
    Camera camera;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void Update()
    {
        base.Update();
        IsClick(); 
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  
        float vertical = Input.GetAxisRaw("Vertical");  
        movementDirection = new Vector2(horizontal, vertical).normalized; 

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
                    SceneManager.LoadScene("Game"); 
                }
            }
        }
    }
}