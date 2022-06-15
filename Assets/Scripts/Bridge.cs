using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour{
    public List<GameObject> brickList = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++){
            brickList.Add(transform.GetChild(i).gameObject);
        }
    }

    
    void Update()
    {
        
    }

    
}
