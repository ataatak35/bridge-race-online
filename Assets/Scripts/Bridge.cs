using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour{
    public List<GameObject> brickList = new List<GameObject>();
    public GameObject stopper;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++){
            brickList.Add(transform.GetChild(i).gameObject);
        }
        stopper = transform.GetChild(20).gameObject;
    }

    
    void Update()
    {
        
    }

    
}
