using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField] private Transform[] m_HazardPrefabs;

    [SerializeField] private Transform[] m_SpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        var trigerrer = GetComponentInChildren<Triggerer>();
        trigerrer.TriggerEnter.AddListener(DestroyGameObject);
        var hazard = Instantiate(m_HazardPrefabs[Random.Range(0, m_HazardPrefabs.Length)]);
        hazard.position = m_SpawnPoints[Random.Range(0, m_SpawnPoints.Length)].position;
        hazard.gameObject.SetActive(true);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
