using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  // 이동 방향
        float vertical = Input.GetAxisRaw("Vertical");   //이동 방향 
        movementDirection = new Vector2(horizontal, vertical).normalized;
    }
}
