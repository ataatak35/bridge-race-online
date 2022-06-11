using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{
    private BrickGenerator brickGenerator;
    void Start()
    {
        brickGenerator = GameObject.Find("BrickGenerator").GetComponent<BrickGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other){
        StartCoroutine(WaitAndCreate(transform.position));
        Debug.Log("Exit");
    }

    IEnumerator WaitAndCreate(Vector3 pos){
        yield return new WaitForSeconds(3);
        brickGenerator.CheckAndCreateDelayedBricks(pos);
    }
}
