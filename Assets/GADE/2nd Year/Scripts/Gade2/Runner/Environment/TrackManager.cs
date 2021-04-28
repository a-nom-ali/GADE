using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private Transform[] m_Prefabs;
    [SerializeField] private float m_ForwardOffset = 16f;
    [SerializeField] private int m_Segments = 16;

    private float _lastForward;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var prefab in m_Prefabs)
        {
            prefab.gameObject.SetActive(false);
        }

        for (int i = 0; i < m_Segments; i++)
        {
            NewSegment();
        }
    }

    public void NewSegment()
    {
        var segment = Instantiate(m_Prefabs[Random.Range(0, m_Prefabs.Length)], transform);
        var pos = segment.transform.position;
        pos.z = _lastForward;
        segment.transform.position = pos;
        segment.gameObject.SetActive(true);

        _lastForward += m_ForwardOffset;
    }
}
