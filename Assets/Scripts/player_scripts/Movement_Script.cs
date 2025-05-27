using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



public class Movement_Script : MonoBehaviour
{
    public float Speed = 30f;
    public float RotationSpeed = 360f;
    float SprintSpeed;
    float InitialSpeed;
    float CurrentSpeed = 0;
    float Delay;
    float Delay2;
    bool Hidden;
    bool Sprinting;
    public float Stamina = 1;
    Vector3 moveAbsolute;
    Vector3 move;
    Rigidbody rb;
    public Transform Body;
    public Image StaminaBar;
    public Vector3 SpawnPoint;
    public GameObject itself;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SprintSpeed = 3 * Speed;
        InitialSpeed = Speed;
        Hidden = false;
        SpawnPoint = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), rb.velocity.y, Input.GetAxis("Vertical"));
        rb.velocity = move * Speed;
       
        

        if (move.x != 0 || move.z != 0)
        {
            Body.rotation = Quaternion.RotateTowards(Body.rotation, Quaternion.LookRotation(-move), RotationSpeed * Time.deltaTime);
        }

        if (Input.GetButton("Sprint")&& Stamina >= 0)
        {
            Speed = SprintSpeed;
            CurrentSpeed = SprintSpeed;
            Sprinting = true;
        }
        else
        {
            Speed = InitialSpeed;
            Sprinting = false;
        }
        if(Sprinting == true)
        {
            Stamina -= 0.20f*Time.deltaTime;
            Debug.Log(Stamina);
            Delay = Time.time;
            StaminaBar.fillAmount = Stamina;
        }
        if(Sprinting == false && Delay +3 <Time.time)
        {
            Stamina += 0.30f*Time.deltaTime;
            StaminaBar.fillAmount = Stamina;
            if (Stamina >= 1)
            {
                Stamina = 1;
            }
        }
    }
    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "HidingPlace")
            {
                Hidden = true;
                Debug.Log("hidden");
            }
            if(other.gameObject.tag == "enemy")
            {
             
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



