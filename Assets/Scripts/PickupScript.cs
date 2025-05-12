//Noah stevenson
//script that controls picking up and putting down objects with parented objects 
// version 1     9/05/2025


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;



public class PickupScript : MonoBehaviour
{

    public GameObject temp;
    bool PickupPrompt;
    bool PutDownPrompt;
    bool HoldingObject = false;
    string HeldObject;
    private Rigidbody Chedar;
    public int score = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PickupPrompt == true && HoldingObject == false)
        {
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("PickedUp");
                temp.transform.position = transform.position + new Vector3(0, 10, 0);
                temp.transform.SetParent(gameObject.transform, true);
                HoldingObject = true;
            }

        }
        else if (PutDownPrompt == true && HoldingObject ==true)
        {
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("dropped");
                temp.transform.SetParent(null, true);
                temp.GetComponent<Rigidbody>().useGravity = true;
                temp.GetComponent<Rigidbody>().isKinematic = false;
                score += temp.GetComponent<ItemControler>().Score;
                temp.gameObject.tag = "Scored";
                HoldingObject = false;
                temp = null;


            }

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pickup")
        {
            PickupPrompt = true;
            temp = other.gameObject;

        }
        else if (other.gameObject.tag == "pizza")
        {
            PutDownPrompt = true;
            

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Pickup")
        {
            PickupPrompt = false;
            
        }


    }

}
