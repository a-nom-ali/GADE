using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Vector3 m_Offset = new Vector3(0, 2, -5);
    [SerializeField] private Vector3 m_Velocity;
    [SerializeField] private float m_FollowSmoothTime = 1f;
    [SerializeField] private Transform m_Target;
    private Transform _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main.transform;
        _camera.position = m_Target.position + m_Offset;
        _camera.LookAt(m_Target);
    }

    private void FixedUpdate()
    {
        Vector3.SmoothDamp(_camera.position, m_Target.position + m_Offset, ref m_Velocity, m_FollowSmoothTime);
        _camera.position += m_Velocity * Time.deltaTime;
        _camera.LookAt(m_Target);
    }
}
