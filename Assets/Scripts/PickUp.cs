using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{ float throwforce = 600;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public GameObject Item;
    public GameObject tempParent;
    public bool isHolding = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Item.transform.position, tempParent.transform.position);
        if (distance >= 3f)
        {
            isHolding = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(isHolding == true) 
            
            {
                isHolding = false; 
                
            }
            else 
                if (distance <= 3f)
            {
                isHolding = true;
                Item.GetComponent<Rigidbody>().isKinematic = false;
            }
        
        
        }
        if (isHolding == true)
        {
            Item.GetComponent <Rigidbody>().velocity = Vector3.zero;
            Item.GetComponent <Rigidbody>().angularVelocity = Vector3.zero;
            Item.transform.SetParent(tempParent.transform);

            if (Input.GetMouseButton(1))
            {
                Item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwforce);
                isHolding =false;            
            }
        }
        else
        {
            objectPos = Item.transform.position;
            Item.transform.SetParent(null);
            Item.GetComponent<Rigidbody>().useGravity = true;
            Item.transform.position = objectPos;
        }
        
    }
}
