using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemControler : MonoBehaviour
{
    public int Score;
    public Vector3 Spawn;
    // score for each object must be manually set in the editor
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pizza")
        {
            this.GetComponent<Rigidbody>().isKinematic = true;

        }
    

    }

}

