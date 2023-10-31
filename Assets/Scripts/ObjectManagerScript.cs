using UnityEngine;

public class ObjectManagerScript : MonoBehaviour
{
    float _rotateSpeed = 200f;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);
    }

}// Class
