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
using TMPro;




public class PickupScript : MonoBehaviour
{
    
    public GameObject ObjectName;
    public Vector3 HeldObjectSpawn;
    bool PickupPrompt;
    bool PutDownPrompt = false;
    bool HoldingObject = false;
    private Rigidbody Chedar;
    public int score = 0;
    int IngridientsNumber =0;
    public GameObject StaminaBar;
    public GameObject WinScreen;
    public TextMeshProUGUI ScoreNumber;
   

    // Update is called once per frame
    void Update()
    {
        if (PickupPrompt == true && HoldingObject == false)
        {
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("PickedUp");
                ObjectName.transform.position = transform.position + new Vector3(0, 10, 0);
                ObjectName.transform.SetParent(gameObject.transform, true);
                HoldingObject = true;
                PickupPrompt = false;
            }

        }
        else if (PutDownPrompt == true && HoldingObject == true)
        {
            if (Input.GetButtonDown("Interact"))
            {
                ObjectName.transform.SetParent(null, true);
                ObjectName.GetComponent<Rigidbody>().useGravity = true;
                ObjectName.GetComponent<Rigidbody>().isKinematic = false;
                score += ObjectName.GetComponent<ItemControler>().Score;
                ObjectName.gameObject.tag = "Scored";
                HoldingObject = false;
                Debug.Log(ObjectName.transform.parent);
                ObjectName = null;
                HeldObjectSpawn = Vector3.zero;
                IngridientsNumber++;
                
                if ( IngridientsNumber == 5)
                {
                    Debug.Log("Win");
                    StaminaBar.SetActive(false);
                    WinScreen.SetActive(true);
                    GetComponent<Movement_Script>().enabled = false;
                    ScoreNumber.text = score.ToString();

                }
            }

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pickup" && HoldingObject == false)
        {
            PickupPrompt = true;
            ObjectName = other.gameObject;
            HeldObjectSpawn = other.transform.position;

        }
        else if (other.gameObject.tag == "pizza")
        {
            PutDownPrompt = true;
            
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Pickup" && HoldingObject == false)
        {
            PickupPrompt = false;
            ObjectName = null;
            HeldObjectSpawn = Vector3.zero;

            
        }
        else if(other.gameObject.tag == "pizza")
        {
            PutDownPrompt = false;

        }

    }
    public void ObjectReset()
    {
        if (ObjectName != null)
        {

            ObjectName.transform.SetParent(null, true);
            ObjectName.transform.position = HeldObjectSpawn;
            ObjectName = null;
            HoldingObject = false;
        }
    }
}
