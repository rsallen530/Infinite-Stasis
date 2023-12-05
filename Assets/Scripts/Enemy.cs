using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 20f;
    public float midDist = 1f;
    public Transform target; 

    // Start is called before the first frame update
    void Start()
    { if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        //face the target 
        transform.LookAt(target);
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > midDist)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

        }
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
