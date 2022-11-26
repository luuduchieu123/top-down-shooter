using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float runSpeed = 1f;

    [SerializeField] public int health;
    Rigidbody2D rb;
    Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }


    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * runSpeed;
        float vertical = Input.GetAxis("Vertical") * runSpeed;
        //transform.Translate(horizontal, vertical, 0);
        
        rb.velocity = new Vector2(horizontal, vertical);
        
        bool playerRun = Mathf.Abs(rb.velocity.x + rb.velocity.y) > Mathf.Epsilon;
        animator.SetBool("IsRunning", playerRun);
    }

    public int GetHealth()
    { return health; }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "health")
        {
            health++;
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
    }
}
