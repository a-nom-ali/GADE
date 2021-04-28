using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_Speed = 1f;
    [SerializeField] private float m_LaneChangeSpeed = 2f;
    [SerializeField] private float m_LaneWidth = 2f;
    private Rigidbody _rigidbody;
    private int _currentLane = 0;

    public Vector3 CurrentLaneLerp
    {
        get
        {
            var targetPosition = transform.position;
            targetPosition.x = _currentLane * m_LaneWidth;
            return Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * m_LaneChangeSpeed);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Crouch();
        }
    }    
    void FixedUpdate()
    {
        _rigidbody.MovePosition(CurrentLaneLerp + Time.fixedDeltaTime * m_Speed * Vector3.forward);
    }
    
    private void Crouch()
    {
        throw new System.NotImplementedException();
    }

    private void Jump()
    {
        throw new System.NotImplementedException();
    }

    private void Left()
    {
        _currentLane = Mathf.Max(-1, _currentLane - 1);
    }

    private void Right()
    {
        _currentLane = Mathf.Min(1, _currentLane + 1);
    }

}
