using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public bool isclick;

    public PlayerMovement player;
    [SerializeField] public float movementLv = 1;
    const int maxMovementLv = 3;

    public static int bulletLv = 1;
    const int maxbulletLv = 3;

    const int health = 3;

    public Weapon[] weapons;
    public static int gunLv = 0;
    const int maxGunLv = 4;


    public void UpgradeMovementSpeed()
    {
        movementLv += 0.5f;
        if (movementLv > maxMovementLv)
        {
            movementLv = maxMovementLv;
            return;
        }

        player.runSpeed += movementLv;
        isclick = true;

    }

    public void UpgradeBullet()
    {
        bulletLv++;
        isclick = true;

        if (bulletLv > maxbulletLv)
        {
            bulletLv = maxbulletLv;
            return;
        }
    }

    public void UpgradeGun()
    {
        gunLv++;
        isclick = true;
        if (gunLv > maxGunLv)
        {
            gunLv = maxGunLv;
            return;
        }

        else if (gunLv < maxGunLv)
        {
            Destroy(GameObject.FindGameObjectWithTag("Weapon"));
            Instantiate(weapons[gunLv], transform.position, transform.rotation, transform);
        }

        else if (gunLv == maxGunLv)
        {
            Instantiate(weapons[gunLv]);
            //var wp1 = weapons[gunLv].gameObject.GetComponent<ButtletAroundPlayer>();
            //wp1.angle = 0;
            //Instantiate(weapons[gunLv]);
            //wp1.angle = 120;
            //Instantiate(weapons[gunLv]);
            //wp1.angle = 240;
            //Instantiate(weapons[gunLv]);
        }
    }

    public void UpgradeHealth()
    {
        isclick = true;
        player.health += health;
    }
}
