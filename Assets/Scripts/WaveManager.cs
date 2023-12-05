using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject playerController;
    public GameObject playerSpawn;
    public GameObject currentWave;
    public GameObject currentVariation;

    public int wave = 0;
    public int cooldownTime = 10;
    public int remainingEnemies = 0;

    public bool isStartingWave = false;
    // Start is called before the first frame update
    void Start()
    {
        /*if (remainingEnemies == 0 && isStartingWave == false)
        {
            
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingEnemies == 0 && isStartingWave == false)
        {
            Debug.Log("No more enemies");
            StartCoroutine(WaveCooldown());
        }
    }

    public void CheckEnemies()
    {
        /*foreach (var component in currentWave.GetComponents<Enemy>())
        {
            remainingEnemies++;
        }*/
        foreach (Transform child in currentVariation.transform)
        {
            //Debug.Log("The name of this object is " + child.name);
            if (child.gameObject.GetComponent<Enemy>())
            {
                remainingEnemies++;
            }
        }
        Debug.Log("The amount of enemies is " +  remainingEnemies);
    }

    public void StartWave()
    {
        int variations = 0;
        int selectedVariation = 0;
        wave++;
        playerController.transform.position = playerSpawn.transform.position;
        //There is still a wave, continue
        if (GameObject.Find("Wave" + wave))
        {
            currentWave = GameObject.Find("Wave" + wave);
            Debug.Log("Current wave is " + wave);
            foreach (Transform child in currentWave.transform)
            {
                variations++;
            }
            selectedVariation = Random.Range(1, variations);
            Debug.Log("The selected variation is " + selectedVariation + " out of " + variations);
            foreach (Transform child in currentWave.transform)
            {
                if (child.name == "Variation" + selectedVariation)
                {
                    currentVariation = child.gameObject;
                    currentVariation.SetActive(true);
                }
            }
            CheckEnemies();
            isStartingWave = false;
        }
        //No more waves, player has won
        else
        {

        }
    }

    IEnumerator WaveCooldown()
    {
        isStartingWave = true;
        yield return new WaitForSeconds(cooldownTime);
        StartWave();

    }
}
