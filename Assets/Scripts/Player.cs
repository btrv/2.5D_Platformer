using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 20f;

    private int _coinsCollected = 0;
    private CharacterController _controller;
    private float m_yVelosity;
    private bool _canDoubleJump = false;
    private UIManager _uiManager;


    void Start()
    {
        _controller = GetComponent<CharacterController>();

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
            Debug.Log("UI manager is NULL");
    }

    void Update()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalinput, 0, 0);
        Vector3 velosity = direction * _speed;

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_yVelosity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            //check for double jump
            // current m_yVelosity += jumpHeight
            if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump == true)
            {
                m_yVelosity += _jumpHeight * 1.3f;
                _canDoubleJump = false;
            }
              
            m_yVelosity -= _gravity;
        }

        velosity.y = m_yVelosity;

        _controller.Move(velosity * Time.deltaTime);
    }

    public void AddCoin()
    {
        _coinsCollected += 1;
        _uiManager.UpdateCoinsUI(_coinsCollected);
    }
}
