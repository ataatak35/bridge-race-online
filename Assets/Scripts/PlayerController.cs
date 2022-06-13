using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public Transform back;
    public Vector3 backPos;
<<<<<<< Updated upstream
    private string username;
    public string color;
    public List<GameObject> collectedBricks = new List<GameObject>();

    // Start is called before the first frame update
    void Start(){
        color = "red";
        back = transform.GetChild(0);
        backPos = back.transform.localPosition;
    }

    // Update is called once per frame
    void Update(){
        
        
=======
    private float speed;
    private float turningSpeed;
    public string color;
    private Rigidbody rigidbody;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Animator animator;
    
    public List<GameObject> collectedBricks = new List<GameObject>();
    
    void Start(){
        rigidbody = GetComponent<Rigidbody>();
        //animator = transform.GetChild(0).GetComponent<Animator>();
        color = "red";
        back = transform.GetChild(0);
        backPos = back.transform.localPosition;
        speed = 6f;
    }
    
    void Update(){
    }

    void FixedUpdate(){
        rigidbody.velocity = new Vector3(joystick.Horizontal * speed, rigidbody.velocity.y, joystick.Vertical * speed
            );

        if (joystick.Horizontal != 0 || joystick.Vertical != 0){
            //Debug.Log(rigidbody.velocity);
            transform.rotation = Quaternion.LookRotation(new Vector3(-rigidbody.velocity.z, rigidbody.velocity.y, rigidbody.velocity.x));
            animator.SetBool("isRunning", true);
        }
        else{
            animator.SetBool("isRunning", false);
        }
>>>>>>> Stashed changes
    }

    private void OnTriggerEnter(Collider other){
        
    }
}
