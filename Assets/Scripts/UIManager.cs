using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Player_controller playerController;
    public WaveManager waveManager;
    public TMP_Text healthText;
    public TMP_Text ammoText;
    public TMP_Text waveText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + playerController.playerHealth;
        if (playerController.currentWeapon != null)
            ammoText.text = playerController.currentWeapon.ammo + " / " + playerController.currentWeapon.allAmmo;
        else 
            ammoText.text = "0 / 0";
        waveText.text = "Wave: " + waveManager.wave + "\n" + "Enemies: " + waveManager.remainingEnemies;
    }
}
