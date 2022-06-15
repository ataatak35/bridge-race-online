using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Photon.Pun;
using Random = UnityEngine.Random;

public class PlayerCollider : MonoBehaviourPunCallbacks{
    private PlayerController playerController;
    private GameObject back;
    private Bridge bridge;
    Dictionary<String,Material> colorMaterialDictionary;
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material blueMaterial;
    [SerializeField] private Material greenMaterial;

    void Start(){
        
        playerController = transform.parent.GetComponent<PlayerController>();
        colorMaterialDictionary = new Dictionary<string, Material>{
            {"Red", redMaterial},
            {"Blue", blueMaterial},
            {"Green", greenMaterial},
        };    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("Platform Upgrade"))
        {

            ((GameObject)PhotonNetwork.MasterClient.TagObject).GetComponent<PhotonView>().RPC("GenerateBricks",RpcTarget.All,other.gameObject);

        }
        
        
        if (other.tag.Equals(playerController.color)){
            playerController.collectedBricks.Add(other.gameObject);
            other.transform.DOLocalMove(playerController.backPos, 0.3f);
            other.transform.SetParent(playerController.back);
            //Sırta geldikten sonra rotation ve scale değişimi önlemek için
            other.transform.localRotation = new Quaternion(0, 0, 0, 0);
            other.transform.localScale = new Vector3(1f, 1f, 1f);
            //other.transform.DORotate(new Vector3(360, 0, 0), 0.1f);
            playerController.backPos.y += 1.1f;
        }

        if (other.tag.Equals("brick") && playerController.collectedBricks.Count > 0){
            bridge = other.gameObject.transform.parent.GetComponent<Bridge>();
            //bridge.stopper.transform.localPosition = bridge.brickList[bridge.brickList.IndexOf(other.gameObject)+2].transform.localPosition;
            other.tag = "created";
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.GetComponent<MeshRenderer>().material = colorMaterialDictionary[playerController.color]; 
            Destroy(playerController.collectedBricks[playerController.collectedBricks.Count-1]);
            playerController.collectedBricks.RemoveAt(playerController.collectedBricks.Count-1);
            playerController.backPos.y -= 1.1f;
            //ridge.slopePlane.transform.localScale += new Vector3(3, 0, 0);
        }
        
    }

    
    
}
