using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks{
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
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        joystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
        //animator = transform.GetChild(0).GetComponent<Animator>();
        back = transform.GetChild(0);
        backPos = back.transform.localPosition;
        speed = 6f;
    }
    
    void FixedUpdate()
    {

        if (!photonView.IsMine)
            return;
        
        rigidbody.velocity = new Vector3(joystick.Horizontal * speed, rigidbody.velocity.y, joystick.Vertical * speed
            );

        if (joystick.Horizontal != 0 || joystick.Vertical != 0){
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
            playerAnimator.SetBool("isRunning", true);
            backAnimator.SetBool("isRunning", true);
        }
        else{
            playerAnimator.SetBool("isRunning", false);
            backAnimator.SetBool("isRunning", false);
        }
    }

}
