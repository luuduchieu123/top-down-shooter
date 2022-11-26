using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float health;
    public int damage;
    public float speed;
    public float timeBetweenAttack;
    public List<GameObject> objs;
    
   
    public Transform playerTransform;

    public virtual void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;    
    }
    
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject rand = objs[Random.Range(0, objs.Count)];
            if (rand == null)
            {
                return;
            }
            GameObject title = Instantiate(rand, transform.position, Quaternion.identity);
            Destroy(title, 5f);
        }
    }
}
