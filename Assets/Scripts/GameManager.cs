using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    //TODO: Playerlar'ı instantiate edicez.
    //TODO: Test amacı: farklı room isimleri de olsa aynı scene yüklenince aynı sahnede mi yer alacaklar yoksa yalnız mı olacaklar?
    //TODO: istenen: farklı odalarda olmaları ama aynı sahneyi yüklemeleri. yani 2 ayrı arena 2 ayrı oda ancak arena dizaynı tek sahnede o da TestScene.
    
    
    private string playerPrefabName = "Player";
    private Vector3 _spawnPos = new Vector3(0,5f,0);
    
    
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefabName, _spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
