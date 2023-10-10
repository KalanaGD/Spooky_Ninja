using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    float _rotateSpeed = 200f;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);
    }

}// Class
