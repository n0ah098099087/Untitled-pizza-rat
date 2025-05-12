using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemControler : MonoBehaviour
{
    public int Score;
    // score for each object must be manually set in the editor
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            this.GetComponent<Rigidbody>().isKinematic = true;

        }
    

    }

}

