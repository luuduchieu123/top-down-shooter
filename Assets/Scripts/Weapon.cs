using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public GameObject projectile;
    [SerializeField] public Transform shotPoint;
    [SerializeField] public float timeBetweenShot;
    [SerializeField] public float shotTime;
    Audio audioClip;

    void Start()
    {
        audioClip = FindObjectOfType<Audio>();
    }

    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        
        if(Quaternion.Angle(transform.rotation, rotation) > 5f)
        {
            transform.rotation = rotation;
        }
        
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= shotTime)
            {
                if (SkillManager.bulletLv == 1)
                {
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                }
                else if (SkillManager.bulletLv == 2)
                {

                    Instantiate(projectile, shotPoint.position, transform.rotation * Quaternion.Euler(0, 0, 30));
                    Instantiate(projectile, shotPoint.position, transform.rotation);

                }

                else if (SkillManager.bulletLv == 3)
                {

                    Instantiate(projectile, shotPoint.position, transform.rotation * Quaternion.Euler(0, 0, 30));
                    Instantiate(projectile, shotPoint.position, transform.rotation * Quaternion.Euler(0, 0, -30));
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                }

                audioClip.PlayShootingClip();
                shotTime = Time.time + timeBetweenShot;
            }
        }       
    }
}
