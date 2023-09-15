using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
     public SceneManager sceneManager;

    float _rotateSpeed = 200f;

    private string _player = "Player";
    private string _level1 = "Level1";

    private void Start()
    {
        sceneManager = GetComponent<SceneManager>();
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
