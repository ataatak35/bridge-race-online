using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField]private GameObject _player;
    private Vector3 _offset;
    void Start()
    {
        _offset = new Vector3(0f, 5f, -5f);
    }
    
    private void LateUpdate()
    {

        transform.position = _player.transform.position + _offset;

    }
}
