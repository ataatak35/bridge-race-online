using System;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviourPunCallbacks{
    
    private string username;
    private string color;

    [SerializeField] private Material redMaterial;
    [SerializeField] private Material blueMaterial;
    [SerializeField] private Material greenMaterial;
    //private Color c = new Color();
    Dictionary<String,Material> colorMaterialDictionary;

    // Start is called before the first frame update
    private void Awake()
    {
        colorMaterialDictionary = new Dictionary<String, Material>{
            {"Red", redMaterial},
            {"Blue", blueMaterial},
            {"Green", greenMaterial},
        };    
    }

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string Color
    {
        get => color;
        set => color = value;
    }

    [PunRPC]
    public void UpdateSpawnPositionsList(int index)
    {
        
        GameObject.FindGameObjectsWithTag("Empty Spawn Position")[index].tag = "Full Spawn Position";
        
    }
    
}
