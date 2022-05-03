using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed;
    private float _turningSpeed;
    
    void Start()
    {
        _speed = 5f;
        _turningSpeed = 10f;
    }

    private void FixedUpdate()
    {
        
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movementX, 0, movementZ);
        
        transform.Translate(movement * _speed * Time.fixedDeltaTime, Space.World);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), Time.fixedDeltaTime * _turningSpeed);

    }
}
