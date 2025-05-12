using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;



public class Movement_Script : MonoBehaviour
{
    public float Speed = 30f;
    public float RotationSpeed = 360f;
    float SprintSpeed;
    float InitialSpeed;
    float CurrentSpeed = 0;
    bool Hidden;
    Vector3 moveAbsolute;
    Vector3 move;
    Rigidbody rb;
    public Transform Body;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SprintSpeed = 3 * Speed;
        InitialSpeed = Speed;
        Hidden = false;

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), rb.velocity.y, Input.GetAxis("Vertical"));
        rb.velocity = move * Speed;
       
        

        if (move.x != 0 || move.z != 0)
        {
          Body.rotation = Quaternion.RotateTowards(Body.rotation, Quaternion.LookRotation(- move),RotationSpeed *Time.deltaTime);
          
        }

        if (Input.GetButton("Sprint"))
        {
            Speed = SprintSpeed;
            CurrentSpeed = SprintSpeed;

        }
        else
        {
            Speed = InitialSpeed;
            
        }

      
    }
    void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "HidingPlace")
            {
                Hidden = true;
                Debug.Log("hidden");
            }
    }

      void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "HidingPlace")
            {
                Hidden = false;
                Debug.Log("not hidden");
            }
      }
    
        
    }



