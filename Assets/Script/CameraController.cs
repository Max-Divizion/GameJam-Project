using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float _mouseSensivity; //�������� �����
    [SerializeField] float _maxYAngle; //������������ ���� �������� �� ���������
    float _rotationX = 0f;
    private float _mouseX;
    private float _mouseY;


    private void FixedUpdate()
    {
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        //�������� ����� �� �����������
        transform.parent.Rotate(eulers: Vector3.up * _mouseX * _mouseSensivity);


        //�������� ������ �� ���������
        _rotationX -= _mouseY * _mouseSensivity;
        _rotationX = Mathf.Clamp(value: _rotationX, min: -_maxYAngle, _maxYAngle);
        transform.localRotation = Quaternion.Euler(_rotationX, y: 0.0f, z: 0.0f);



    }

}
