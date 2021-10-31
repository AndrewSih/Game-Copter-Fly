using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowRoot : MonoBehaviour // ����� ���������� ������ ��������� ������ �� x 
{

    private float _initialYPosition;

    private void Start()
    {
        _initialYPosition = transform.position.y;
    }

    private void Update()
    {
        var position = transform.position;
        position.y = _initialYPosition;
        transform.position = position;
    }
}
