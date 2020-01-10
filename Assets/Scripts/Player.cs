using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 20f;
    [SerializeField] private int _lives = 3;
    [SerializeField] private GameObject _startPoint;

    private Transform _spawnPoint;
    private int _coinsCollected = 0;
    private CharacterController _controller;
    private float m_yVelosity;
    private bool _canDoubleJump = false;
    private UIManager _uiManager;

    // private Vector3 _startPosition = new Vector3 (0, 1.8f, 0);


    void Start()
    {
        // _spawnPoint = GameObject.Find("Spawn_Point").GetComponent<Transform>();
        transform.position = _startPoint.transform.position;

        _controller = GetComponent<CharacterController>();

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
            Debug.Log("UI manager is NULL");

        _uiManager.UpdateLivesUI(_lives);
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
                m_yVelosity += _jumpHeight * 1.25f;
                _canDoubleJump = false;
            }
              
            m_yVelosity -= _gravity;
        }

        velosity.y = m_yVelosity;

        _controller.Move(velosity * Time.deltaTime);

        // LooseLife();
    }

    public void AddCoin()
    {
        _coinsCollected += 1;
        _uiManager.UpdateCoinsUI(_coinsCollected);
    }

    public void LooseLife()
    {
        _lives--;
        Debug.Log("Lives - 1");
        _uiManager.UpdateLivesUI(_lives);

        if(_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.tag == "Floor")
    //     {
    //         _lives--;
    //         Debug.Log("Lives - 1");
    //         _uiManager.UpdateLivesUI(_lives);
    //         StartCoroutine(ResetPositionAtSec());
    //     }

    //     if(_lives < 1)
    //     {
    //         // _gameManager.Restart();
    //         SceneManager.LoadScene(0);
    //     }
    // }

    // IEnumerator ResetPositionAtSec()
    // {
    //     yield return new WaitForSeconds (0.1f);
    //     this.transform.position = _spawnPoint.transform.position;
    // }
}
