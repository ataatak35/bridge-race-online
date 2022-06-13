using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public Transform back;
    public Vector3 backPos;
    private float speed;
    private float turningSpeed;
    public string color;
    private Rigidbody rigidbody;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator backAnimator;
    
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
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
            playerAnimator.SetBool("isRunning", true);
            backAnimator.SetBool("isRunning", true);
        }
        else{
            playerAnimator.SetBool("isRunning", false);
            backAnimator.SetBool("isRunning", false);
        }
    }

    private void OnTriggerEnter(Collider other){
        
    }
}
