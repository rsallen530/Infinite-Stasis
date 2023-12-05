using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int ammo = 100;
    public int maxAmmo = 100;
    public bool melee = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        if (!melee)
        {
            if (ammo <= 0)
            {
                // Reload here
            }
            else
            {
                ammo -= 1;
            }
        }
    }
}
