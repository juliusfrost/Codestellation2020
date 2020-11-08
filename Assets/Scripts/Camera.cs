using UnityEngine;

public class Camera : MonoBehaviour
{

    private GameObject _player;
    [SerializeField] private float followScale = 0.01f;
    private Transform _cameraTransform;
    private Transform _targetTransform;

    // Start is called before the first frame update
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _targetTransform = _player.GetComponent<Transform>();
        _cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        var position = _cameraTransform.position;
        var difference = Vector3.Scale((_targetTransform.position - position), new Vector3(1, 1, 0));

        position += difference * followScale;
        _cameraTransform.position = position;
    }
}
