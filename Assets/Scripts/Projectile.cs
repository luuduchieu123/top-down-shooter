using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    [SerializeField] GameObject explosion;
    [SerializeField] int damage;
    Audio audioClip;
    SkillManager skill;

    void Awake()
    {
        audioClip = FindObjectOfType<Audio>();
        skill = FindObjectOfType<SkillManager>();
    }

    void Start()
    {
        Invoke("PlayParitcle", lifeTime);
        Destroy(gameObject, lifeTime);
    }


    void Update()
    {
        transform.Translate(Vector2.up * speed * skill.movementLv * Time.deltaTime);
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
            audioClip.PlayDamageClip();
            Destroy(gameObject);
        }
    }
}
