using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        Vector3 _tempPos = transform.position;
        _tempPos.x = _player.position.x;

        transform.position = _tempPos;
        
    }

}// Class


