using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy
{
    [SerializeField] float timeBetweenSummon;
    [SerializeField] float summonTime;
    [SerializeField] GameObject enemyToSummon;
    Coroutine coroutine;

    public override void Start()
    {
        base.Start();

    }


    void Update()
    {
        if (playerTransform != null)
        {
            if (Vector2.Distance(transform.position, playerTransform.position) > 5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

            }
            else
            {
                if (coroutine == null)
                {
                    coroutine = StartCoroutine(FireContinuosly());
                }

                else if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
            }

            //else
            //{
            //   if(Time.deltaTime >= summonTime)
            //    {
            //        summonTime = Time.deltaTime + timeBetweenSummon;
            //    }

            //}
        }
    }

    IEnumerator FireContinuosly()
    {
        GameObject instance = Instantiate(enemyToSummon, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBetweenSummon);

    }
}