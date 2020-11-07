using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private float followScale = 0.01f;
    private Transform _cameraTransform;
    private Transform _targetTransform;

    // Start is called before the first frame update
    private void Start()
    {
        if (target == null) {
            Debug.Log("target not set!");
        }
        _targetTransform = target.GetComponent<Transform>();
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
