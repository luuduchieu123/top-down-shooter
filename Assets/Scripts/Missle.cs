using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    public Transform enemy;
    [SerializeField] float lifeTime;
    [SerializeField] GameObject explosion;
    [SerializeField] int damage;
    //public GameObject bullet;

    //List<GameObject> bullets = new List<GameObject>();

    private void Start()
    {
        enemy = FindObjectOfType<CheckTrigger>().e;
        //for (int i = 0; i < 1; i++)
        //{
        //GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
        //bullets.Add(b);
        Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        gameObject.transform.up = dir;

        Invoke("PlayParitcle", lifeTime);
        Destroy(gameObject, lifeTime);
        //}
    }
    private void Update()
    {
        if (enemy == null)
        {
            Destroy(this.gameObject);
            return;
        }

        if (Time.time > 0.3f)
        {
            //for (int i = 0; i < 1; i++)
            //{
            
            //else
            //{
                Vector2 direction = enemy.position - gameObject.transform.position;
                //bullets[i].GetComponent<Rigidbody2D>().velocity = direction.normalized * 5f;

                float unityAngle = Vector3.SignedAngle(gameObject.transform.up, direction, this.transform.forward);
                gameObject.transform.Rotate(0, 0, unityAngle * .02f);

                Quaternion lookDir = Quaternion.LookRotation(direction, gameObject.transform.up);
                //bullets[i].transform.rotation = Quaternion.Slerp(bullets[i].transform.rotation, lookDir, Time.deltaTime);

                gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.Euler(0, 0, unityAngle), Time.deltaTime);
                gameObject.transform.Translate(transform.up * 10 * Time.deltaTime);
            //}
        }
        else
        {
            //for (int i = 0; i < 1; i++)
            //{
            gameObject.transform.Translate(transform.up * 7 * Time.deltaTime);

            //}
        }

    }

    void PlayParitcle()
    {

        Instantiate(explosion, transform.position, Quaternion.identity);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            PlayParitcle();
            Destroy(gameObject);
        }
    }
}
