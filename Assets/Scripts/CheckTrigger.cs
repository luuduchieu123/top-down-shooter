using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    public Transform e;

    void Start()
    {
        e = null;
    }
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            e = FindObjectOfType<Enemy>().transform;
            //Debug.Log(e.position);
        }
    }
}
