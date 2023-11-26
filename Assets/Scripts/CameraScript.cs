using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform _player;
    private PlayerScript _playerScriptInstance;
    public bool _gameFinished;

    private Animator _anim;


    


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _playerScriptInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();


        _anim = GetComponent<Animator>();   

    }

    private void LateUpdate()
    {
        Vector3 _tempPos = transform.position;
        _tempPos.x = _player.position.x;

        transform.position = _tempPos;
    }

    private void Update()
    {
        _gameFinished = _playerScriptInstance._gameFinished;

        if (_gameFinished)
        {
            _anim.SetBool("shake",true);
        }
    }


}// Class

