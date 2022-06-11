using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public Transform back;
    public Vector3 backPos;
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
        
        
    }

    private void OnTriggerEnter(Collider other){
        
    }
}
