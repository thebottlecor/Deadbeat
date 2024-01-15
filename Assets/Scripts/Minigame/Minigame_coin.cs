using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame_coin : MonoBehaviour
{

    public static EventHandler<int> GetEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Coin!");
            gameObject.SetActive(false);

            if (GetEvent != null)
                GetEvent(this, 0);
        }
    }
}
