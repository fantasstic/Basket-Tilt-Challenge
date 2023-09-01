using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformContoller : MonoBehaviour
{

    [SerializeField] private float _maxTiltAngle = 45f; 

    private Vector2 _touchStartPos; 
    private bool _isTouching = false; 
    private float _currentTiltAngle = 0f; 

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _touchStartPos = touch.position;
                _isTouching = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _isTouching = false;
            }
        }
        else
        {
            _isTouching = false;
        }

        if (_isTouching)
        {
            float swipeDistance = Input.GetTouch(0).position.x - _touchStartPos.x;
            _currentTiltAngle = Mathf.Clamp(swipeDistance / Screen.width * _maxTiltAngle * 2f, -_maxTiltAngle, _maxTiltAngle);
        }
        transform.rotation = Quaternion.Euler(0f, 0f, -_currentTiltAngle);
    }
}
