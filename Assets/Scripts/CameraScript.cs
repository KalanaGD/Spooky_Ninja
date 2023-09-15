using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform _player;

    private void LateUpdate()
    {
        Vector3 _tempPos = transform.position;

        _tempPos.x = _player.position.x;



        transform.position = _tempPos;
        
    }
}
