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

    public Vector3 spread = new Vector3(0.1f, 0.1f, 0.1f);

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

    public virtual void Fire()
    {
        if (!melee)
        {
            if (!reloading && allAmmo > 0 && shootCooldown + shootInterval < Time.time)
            {
                shootCooldown = Time.time;
                if (ammo <= 0)
                {
                    Reload();
                }
                else
                {
                    Shoot();
                    ammo--;
                }
            }
        }
    }

    public void Shoot()
    {
        Debug.Log("Fire");
        if (Physics.Raycast(transform.position, CalculateSpread(), out RaycastHit hit, float.MaxValue))
        {
            GameObject target = hit.transform.gameObject;
            if (target.GetComponent<Enemy>() != null)
            {
                Debug.Log("Hit Enemy!");
                target.GetComponent<Enemy>().enemyHealth -= 1;
            }
        }
    }

    public void Reload()
    {
        if (!reloading && allAmmo > 0)
        {
            Debug.Log("Reloading");
            StartCoroutine(ReloadTime());
        }
    }

    private Vector3 CalculateSpread()
    {
        Vector3 spreadForward = transform.forward;
        spreadForward += new Vector3(Random.Range(-spread.x, spread.x), Random.Range(-spread.y, spread.y), Random.Range(-spread.z, spread.z));
        spreadForward.Normalize();
        return spreadForward;
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
        if (ammo > maxAmmo) ammo = maxAmmo;
        reloading = false;
        Debug.Log("Reloaded");
    }
}
