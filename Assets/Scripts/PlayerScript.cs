using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject _quitBTN;
    [SerializeField] GameObject _finishBTN;
    [SerializeField] GameObject _jumpFX;
    [SerializeField] Transform _jumpPoint;

    private Rigidbody2D _rb;
    private Animator _anim;
    [SerializeField] private Animator _anim2;

    private float _jumpForce = 8f;
    private float _moveSpeed = 4f;
    private string _jumpParameter = "Jumping";

    public bool _gameFinished = false;
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
        PlayerMoveProcess();
        AfterUse();
        
    }




    private void AfterUse()
    {
        if (_gameFinished || _dead)
        {
            _moveSpeed = 0;
            _jumpForce = 0;
        }
    }

    private void PlayerMoveProcess()
    {
        if (_gameFinished) return;
        {
            if (Input.GetMouseButtonDown(0))
            {
                _rb.bodyType = RigidbodyType2D.Dynamic;
                _moveSpeed = 4.5f;

                GameObject _jumpFXclone = Instantiate(_jumpFX,_jumpPoint.position, Quaternion.identity);

                Destroy(_jumpFXclone , 1f);
            }
        }

        if (_dead != true)
        {
            transform.position += new Vector3(_moveSpeed, 0, 0) * Time.deltaTime;

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

    private void OnCollisionEnter2D(Collision2D harmfullobjects)
    {
        if (harmfullobjects.gameObject.CompareTag("PlayerLife"))
        {
            _dead = true;
            _quitBTN.SetActive(false);
            _anim2.SetBool("NoPlayer", true);

            StartCoroutine(RetryGame());
        }
    }

    private IEnumerator RetryGame()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D finishGameBTN)
    {
        if (finishGameBTN.gameObject.CompareTag("NextBTN") && _dead != true)
        {
            _gameFinished = true;
            _rb.bodyType = RigidbodyType2D.Static;
            _quitBTN.SetActive(false);
            
            
        }
    }

}// Class
