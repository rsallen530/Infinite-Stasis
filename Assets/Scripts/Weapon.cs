using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int ammo = 15;
    public int maxAmmo = 15;
    public int allAmmo = 100;
    public int weaponSlot = 0;
    public int reloadTime = 2;

    public bool melee = false;
    public bool reloading = false;

    public float spread = 1;
    public float shootInterval = 0.5f;
    public float shootCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if (!melee)
        {
            if (!reloading && maxAmmo > 0 && shootCooldown + shootInterval < Time.time)
            {
                shootCooldown = Time.time;
                if (ammo <= 0)
                {
                    Debug.Log("Reloading");
                    StartCoroutine(ReloadTime());
                }
                else
                {
                    Debug.Log("Fire");
                    ammo--;
                }
            }
        }
    }

    IEnumerator ReloadTime()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        for (int i = 0; i < maxAmmo || maxAmmo == 0; i++)
        {
            ammo++;
            allAmmo--;
        }
        reloading = false;
        Debug.Log("Reloaded");
    }
}
