using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
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
    public bool Caught;
    public bool Respawning;
    public float Stamina = 1;
    Vector3 moveAbsolute;
    Vector3 move;
    Rigidbody rb;
    public Transform Body;
    public Image StaminaBar;
    public Image BlackScreen;
    public Image SneakyScreen;
    public Vector3 SpawnPoint;
    public Animator RatAnimations;
    public Animator BenchNpc;
    PickupScript pickupScript;
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SprintSpeed = 3 * Speed;
        InitialSpeed = Speed;
        Hidden = false;
        SpawnPoint = transform.position;
        pickupScript = GetComponent<PickupScript>();
    }

    private void Update()
    {
        if (Caught == true && Respawning == true)
        {
            
            BlackScreen.fillAmount += 0.50f * Time.deltaTime ;
            if (BlackScreen.fillAmount >= 1)
            {
                Respawning = false;
                transform.position = SpawnPoint;

            }
        }
        else if (Caught == true && Respawning == false)
        {
            pickupScript.ObjectReset();
            BlackScreen.fillAmount -= 0.60f * Time.deltaTime;
            if (BlackScreen.fillAmount == 0)
            {
                Caught = false;
               
            }

        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {

        if (!Caught)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), rb.velocity.y, Input.GetAxis("Vertical"));
            rb.velocity = move * Speed;
            
            

        }
           RatAnimations.SetBool("Walking", move.magnitude > 0.9);

        if (move.x != 0 || move.z != 0 )
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
        RatAnimations.SetBool("Running", Sprinting);
        if(Sprinting == true)
        {
            Stamina -= 0.20f*Time.deltaTime;
            Delay = Time.time;
            StaminaBar.fillAmount = Stamina;
        }
        if(Sprinting == false && Delay +2 <Time.time)
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
                SneakyScreen.gameObject.SetActive(true);
                
        }
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("caught");
           
            Caught = true;
            Respawning = true;
            rb.velocity = new Vector3(0, 0, 0);
            

        }
        if (other.gameObject.tag == "spotted")
        {
            BenchNpc.SetBool("Angry" , true);

        }
    }
   

      void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "HidingPlace")
            {
                Hidden = false;
                Debug.Log("not hidden");
                SneakyScreen.gameObject.SetActive(false);
            }
            if (other.gameObject.tag == "spotted")
            {
            BenchNpc.SetBool("Angry", false);

            }
    }
    
        
    }



