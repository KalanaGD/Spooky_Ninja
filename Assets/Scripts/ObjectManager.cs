using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{

    float _rotateSpeed = 200f;

    private string _player = "Player";

    private void Start()
    {
       
    }

    private void Update()
    {
        transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag(_player))
        {
           
        }
    }
}
