using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
    private float x;
    private float y;
    public int lives = 3;
    private bool _jump;
    [SerializeField] private float jumpPower = 5;
    [SerializeField] private float torquePower = 1f;
    private Rigidbody _rigidbodyComponent;
    private bool _isGrounded;
    private float _horizontalInput;

    // Start is called before the first frame update
    private void Start()
    {
        var position = transform.position;
        x = position.x;
        y = position.y;

        lives = 3;
        _rigidbodyComponent = GetComponent<Rigidbody>();
        _isGrounded = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;
        }

        _horizontalInput = Input.GetAxis("Horizontal");
        if (lives == 0)
        {
            SceneManager.LoadScene("GameOverScreen");
        }
    }

    public void Death()
    {
        lives--;

        transform.position = new Vector3(x, y, 0);
    }

    // called every physics update
    private void FixedUpdate()
    {
        if (transform.position.y < -3.0f)
        {
            Death();
        }

        if (_jump)
        {
            if (_isGrounded)
                _rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            _jump = false;
        }

        _isGrounded = false;

        // Debug.Log(_horizontalInput);
        // rigidbodyComponent.AddRelativeTorque(new Vector3(0, horizontalInput * torquePower, 0), ForceMode.Impulse);
        _rigidbodyComponent.AddTorque(0, 0, -_horizontalInput * torquePower, ForceMode.VelocityChange);
    }

    private void OnCollisionStay(Collision other)
    {
        _isGrounded = other.contacts.Any(contactPoint => contactPoint.point.y < _rigidbodyComponent.position.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            Destroy(other.gameObject);
        }
    }
}