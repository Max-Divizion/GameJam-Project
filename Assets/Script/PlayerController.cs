using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private CharacterController _controller;

    private float _inputHorizontal;
    private float _inputVertical;

    private Vector3 _moveDirection;


    private void Start()
    {
       _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");
        _inputVertical = Input.GetAxis("Vertical");

        _moveDirection = transform.forward * _inputVertical + transform.right * _inputHorizontal;

        _moveDirection.y -= 10f * Time.deltaTime;

        _controller.Move(motion:_moveDirection * _moveSpeed * Time.deltaTime);


    }


}



