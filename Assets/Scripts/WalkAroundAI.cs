using UnityEngine;

public class WalkAroundAI : MonoBehaviour
{
    [SerializeField] private float walkSeconds = 5;
    [SerializeField] private float torquePower = 1;
    private float _lastTimeDirectionChanged;
    private bool _walkLeft;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _lastTimeDirectionChanged = Time.realtimeSinceStartup;
    }

    private void FixedUpdate()
    {
        if (Time.realtimeSinceStartup - _lastTimeDirectionChanged > walkSeconds)
        {
            _walkLeft = !_walkLeft;
            _lastTimeDirectionChanged = Time.realtimeSinceStartup;
        }

        if (_walkLeft) _rigidbody.AddTorque(0, 0, -torquePower, ForceMode.VelocityChange);
        else _rigidbody.AddTorque(0, 0, torquePower, ForceMode.VelocityChange);
    }
}