using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject _quitBTN;

    private Rigidbody2D _rb;
    private Animator _anim;

    private float _jumpForce = 9f;
    private float _moveSpeed = 4f;
    private string _jumpParameter = "Jumping";
    private bool _finished = false;
    private bool _dead = false;




    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        _moveSpeed = 0;
        _rb.bodyType = RigidbodyType2D.Static;
    }


    void Update()
    {
        PlayerJump();
        PlayerMove();
    }

    
    private void PlayerMove()
    {
        if (_finished!= true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                _rb.bodyType = RigidbodyType2D.Dynamic;
                _moveSpeed = 4.5f;
            }
        }

        if(_dead!= true)
        {
            transform.position += new Vector3(_moveSpeed, 0, 0) * Time.deltaTime;
        }
    }


    private void PlayerJump()
    {
        if (_dead != true) // move speed not equal to '0' then can jump
        {
            if (Input.GetMouseButtonDown(0))
            {
                _rb.velocity = new Vector2(0, _jumpForce);
                _anim.SetBool(_jumpParameter, true);
            }
            else
            {
                _anim.SetBool(_jumpParameter, false);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D harmfullobjects) // after death restart the same mission
    {
        if (harmfullobjects.gameObject.CompareTag("PlayerLife"))
        {
            _dead = true;
            _moveSpeed = 0;
            _jumpForce = 0;
            
            

            _quitBTN.SetActive(false);
           
            StartCoroutine(RetryGame());
        }

    }

    private IEnumerator RetryGame()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void OnTriggerEnter2D(Collider2D finishgameBTN)
    {
        if (finishgameBTN.gameObject.CompareTag("NextBTN"))
        {
            _finished = true;
            _dead = true;   
            _rb.bodyType = RigidbodyType2D.Static;
            _moveSpeed = 0;
            _quitBTN.SetActive(false);
        }
    }
    
}// Class
