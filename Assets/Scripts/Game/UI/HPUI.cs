using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUI : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    public void DecreaseHp()
    {
        if (player.hp >= 0)
        {
            Transform heart = transform.GetChild(player.hp);
            heart.gameObject.SetActive(false);
        }
    }
}
