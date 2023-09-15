using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Animator _anim;

    public Vector3 _jumpForce = new Vector2(0, 10); // for player jump
    private Vector3 _cameraSpeed = new Vector3(5, 0, 0); // for camera movement 
    private string __jumpParameter = "Jumping";



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
   
    void Update()
    {
        PlayerJump();
        PlayerMove();
    }

    private void PlayerMove()
    {
        transform.position += _cameraSpeed * Time.deltaTime; // for camera movement
    }

    private void PlayerJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = _jumpForce; // jump process of the player
            _anim.SetBool(__jumpParameter, true); 
        }
        else 
        {
            _anim.SetBool(__jumpParameter, false);
        }
    }  

   

}// Class
