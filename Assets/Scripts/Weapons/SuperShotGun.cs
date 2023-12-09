using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShotGun : Weapon
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Fire()
    {
        if (!melee)
        {
            if (!reloading && maxAmmo > 0 && shootCooldown + shootInterval < Time.time)
            {
                shootCooldown = Time.time;
                if (ammo <= 0)
                {
                    Reload();
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Shoot();
                    }
                    ammo--;
                }
            }
        }
    }
}
