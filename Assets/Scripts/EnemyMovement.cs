using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy
{
    [SerializeField] float stopDistance;
    [SerializeField] float attackTime;
    [SerializeField] float attackSpeed;
    public bool allowAttack;

    public override void Start()
    {
        base.Start();

    }

    void Update()
    {
        
        if (playerTransform != null)
        {
           
            if (Vector2.Distance(transform.position,playerTransform.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }
            else
            {
                if(allowAttack)
                {
                    if (Time.deltaTime >= attackTime)
                    {
                        StartCoroutine(Attack());
                        attackTime = Time.deltaTime + timeBetweenAttack;
                    }
                }
                
            }
        }
    }

    IEnumerator Attack()
    {
        playerTransform.GetComponent<PlayerMovement>().TakeDamage(damage);
        Vector2 originalPositon = transform.position;
        Vector2 targetPosition = playerTransform.position;
        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = -Mathf.Pow(percent, 2) + percent * 4;
            transform.position = Vector2.Lerp(originalPositon, targetPosition, formula);
            yield return null;
        }
    }
}
