using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;

    private Rigidbody2D _rb;
    private Animator _anim;

    private float _jumpForce = 9f;
    private float _moveSpeed = 3f;
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
        transform.position += new Vector3(_moveSpeed, 0, 0) * Time.deltaTime;
    }

    private void PlayerJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = new Vector2(0, _jumpForce);
            _anim.SetBool(__jumpParameter, true);
        }
        else
        {
            _anim.SetBool(__jumpParameter, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("PlayerLife"))
        {
            _gameOverPanel.SetActive(true);
            _moveSpeed  = 0;
            _jumpForce = 0;
        }
    }


}// Class
