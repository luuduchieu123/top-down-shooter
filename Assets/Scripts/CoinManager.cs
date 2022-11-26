using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int coin = 1;
    public bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player") && !wasCollected)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            FindObjectOfType<UIManager>().AddToScore(coin);
        }
    }
}
