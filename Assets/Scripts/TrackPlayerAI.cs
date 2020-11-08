using UnityEngine;

public class TrackPlayerAI : MonoBehaviour
{
    [SerializeField] private float torquePower = 1;
    private GameObject _player;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        var target = _player.transform.position;
        if (target.x < transform.position.x)
        {
            _rigidbody.AddTorque(0, 0, torquePower, ForceMode.VelocityChange);
        }
        else
        {
            _rigidbody.AddTorque(0, 0, -torquePower, ForceMode.VelocityChange);
        }
    }
}