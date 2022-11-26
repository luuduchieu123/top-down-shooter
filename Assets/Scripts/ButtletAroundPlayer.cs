using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtletAroundPlayer : Weapon
{
   // public GameObject weapon;
    Transform player;

    public Vector2 direction;
    public float angle;
    public float radius;
    public float degreesPerSecond = 60;
    public int damage;
    [SerializeField] GameObject explosion;

    private void Start()
    {
        //transform.position = transform.position + new Vector3(2, 0, 0);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = (transform.position - player.position).normalized;
        radius = Vector2.Distance(player.position, transform.position);
        if (radius > 1) radius = 1;
    }

    private void Update()
    {
        

        for (int i = 0; i < 20; i++)
        {
            angle += degreesPerSecond * Time.deltaTime;
            if (angle >= 360f)
            {
                angle = 0f;
            }
            
          //  angle = Random.Range(0f, 360f);
            Vector2 orbit = transform.up * radius;
            orbit = Quaternion.LookRotation(direction) * Quaternion.Euler(angle, 0, 0) * orbit;
            transform.position = (Vector2)player.position + orbit;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= shotTime)
            {
                //if (SkillManager.bulletLv == 1)
                //{
                Instantiate(projectile, shotPoint.position, transform.rotation);
                // }


                shotTime = Time.time + timeBetweenShot;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
           // Destroy(explosion,0.2f);
        }
    }
}