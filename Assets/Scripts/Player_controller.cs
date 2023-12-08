using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UI;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public GameObject[] inventory;

    public Weapon currentWeapon;

    public GameObject camera;
    public GameObject weaponPlacement;
    public GameObject waveManager;

    public float speed = 10f;
    public float mouseSpeed = 10f;
    public float playerHealth = 99;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private int activeSlot = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inventory = new GameObject[3];
    }

    // Update is called once per frame
    void Update()
    {
        //Fire weapon
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (inventory[activeSlot] != null && currentWeapon != null)
            {
                currentWeapon.Fire();
            }
        }

        // Weapon slots
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SwapWeapon(0);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SwapWeapon(1);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SwapWeapon(2);
        }

        // Movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
        }

        // Interaction
        if (Input.GetKey(KeyCode.E))
        {
            WeaponPickup();
        }

        yaw += mouseSpeed * Input.GetAxis("Mouse X");
        pitch -= mouseSpeed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        camera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }

    void WeaponPickup()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 2.00f))
        {
            GameObject interaction = hit.transform.gameObject;
            //Hit Something
            Debug.Log("Hit Something");
            if (interaction.GetComponent<Weapon>() != null)
            {
                if (inventory[interaction.GetComponent<Weapon>().weaponSlot] != null)
                {
                    GameObject droppedWeapon;
                    Debug.Log("Already has a weapon, dropping previous");
                    droppedWeapon = Instantiate(inventory[interaction.GetComponent<Weapon>().weaponSlot], transform.position, transform.rotation);
                    droppedWeapon.GetComponent<BoxCollider>().enabled = true;
                    //droppedWeapon.transform.parent = waveManager.currentVariation
                }
                inventory[interaction.GetComponent<Weapon>().weaponSlot] = interaction;
                //hit.transform.gameObject.SetActive(false);
                interaction.transform.parent = camera.transform;
                interaction.transform.position = weaponPlacement.gameObject.transform.position;
                interaction.transform.rotation = weaponPlacement.gameObject.transform.rotation;
                SwapWeapon(interaction.GetComponent<Weapon>().weaponSlot);

                //hit.transform.gameObject.GetComponent<Weapon>().Fire();
                //Destroy(hit.transform.gameObject);
            }
        }
    }

    void SwapWeapon(int slot)
    {
        if (inventory[slot] != null)
        {
            activeSlot = slot;
            if (inventory[activeSlot] != null)
            {
                if (inventory[activeSlot].gameObject.GetComponent<Weapon>() != null)
                    currentWeapon = inventory[activeSlot].GetComponent<Weapon>();
            }
            for (int i = 0; i <= inventory.Count() - 1; i++)
            {
                if (inventory[i] != null)
                {
                    if (i != activeSlot) inventory[i].gameObject.SetActive(false);
                    else
                    {
                        inventory[activeSlot].gameObject.GetComponent<BoxCollider>().enabled = false;
                        inventory[activeSlot].gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
