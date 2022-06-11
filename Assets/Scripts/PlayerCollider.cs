using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCollider : MonoBehaviour{
    private PlayerController playerController;
    private GameObject back;
    private Bridge bridge;
    void Start(){
        playerController = transform.parent.GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if (other.tag.Equals(playerController.color)){
            playerController.collectedBricks.Add(other.gameObject);
            other.transform.SetParent(playerController.back);
            other.transform.DOLocalMove(playerController.backPos, 0.3f);
            //other.transform.DORotate(new Vector3(360, 0, 0), 0.1f);
            playerController.backPos.y += 1.1f;
        }

        if (other.tag.Equals("brick") && playerController.collectedBricks.Count > 0){
            int i = 0;
            bridge = other.gameObject.transform.parent.GetComponent<Bridge>();
            other.tag = "created";
            for (i = 0; i < playerController.collectedBricks.Count; i++){
                
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                Destroy(playerController.collectedBricks[playerController.collectedBricks.Count-1]);
                playerController.collectedBricks.RemoveAt(playerController.collectedBricks.Count-1);
                playerController.backPos.y -= 1.1f;
                bridge.slopePlane.transform.localScale += new Vector3(3, 0, 0);
                
                
            }
        }
    }
}
