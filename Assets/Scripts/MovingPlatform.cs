﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]    private Transform _pointA, _pointB;
    [SerializeField]    private float _speed = 2;
                        private bool _switch = false;

    void Update()
    {
        if(_switch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, Time.deltaTime * _speed);
        }
        else if (_switch == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, Time.deltaTime * _speed);
        }

        if (transform.position == _pointB.position)
            _switch = true;
        else if (transform.position == _pointA.position)
            _switch = false;
    }
}
