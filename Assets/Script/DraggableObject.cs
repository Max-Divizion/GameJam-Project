using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class DraggableObject : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _initialScale;
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private bool _follow;
    [SerializeField] private float _followspeed;
    private Vector3 _moveDirection;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!_follow)
            return;
        _moveDirection = _targetPosition - _rigidbody.position;

        _rigidbody.velocity = _moveDirection * _followspeed;
    }

    public void StartFollowingObject()
    {
        _follow = true;
    }

    public void SetTargetPosition(Vector3 newTargetPosition)
    {
        _targetPosition = newTargetPosition;
    }

    public void StopFollowingObject()
    {
        _follow = false;
        _rigidbody.velocity = Vector3.zero;
    }




}
