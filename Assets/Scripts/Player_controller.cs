using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public GameObject[] inventory;

    public GameObject camera;
    public float speed = 10f;
    public float mouseSpeed = 10f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private int activeSlot = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inventory = new GameObject[4];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            activeSlot = 0;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            activeSlot = 1;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            activeSlot = 2;
        }

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
        yaw += mouseSpeed * Input.GetAxis("Mouse X");
        pitch -= mouseSpeed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        camera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // Code for swapping weapons visually should be here

    }
}
