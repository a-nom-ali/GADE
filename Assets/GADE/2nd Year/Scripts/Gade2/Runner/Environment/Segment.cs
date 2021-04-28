using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField] private Transform[] m_HazardPrefabs;
    [SerializeField] private Transform[] m_PickupPrefabs;

    [SerializeField] private Transform[] m_SpawnPoints;

    private Transform[] HazardSpawnPoints => m_SpawnPoints.Where(p => p.CompareTag("Hazard")).ToArray();
    private Transform RandomHazardSpawnPoint => HazardSpawnPoints[Random.Range(0, HazardSpawnPoints.Length)];
    private Transform[] PickupSpawnPoints => m_SpawnPoints.Where(p => p.CompareTag("Pickup")).ToArray();
    private Transform RandomPickupSpawnPoint => PickupSpawnPoints[Random.Range(0, PickupSpawnPoints.Length)];

    // Start is called before the first frame update
    void Awake()
    {
        var trigerrer = GetComponentInChildren<Triggerer>();
        trigerrer.TriggerEnter.AddListener(DestroyGameObject);
        
        var hazard = Instantiate(m_HazardPrefabs[Random.Range(0, m_HazardPrefabs.Length)], RandomHazardSpawnPoint);
        hazard.gameObject.SetActive(true);
        
        var pickup = Instantiate(m_PickupPrefabs[Random.Range(0, m_PickupPrefabs.Length)], RandomPickupSpawnPoint);
        pickup.gameObject.SetActive(true);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
