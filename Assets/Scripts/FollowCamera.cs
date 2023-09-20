using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{    
    private Vector3 _offset;

    [SerializeField] private GameObject _objectFollow;

    void Start()
    {
        _offset = transform.position - _objectFollow.transform.position;
    }

    void LateUpdate()
    {
        transform.position = _objectFollow.transform.position + _offset;
    }
}
