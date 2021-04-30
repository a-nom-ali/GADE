using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    None,
    Candy,
    Bubbles,
    Formula
}
public class Pickup : MonoBehaviour
{
    [SerializeField] private Transform m_Effect;
    public virtual PickupType PickupType => PickupType.None;
    
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        player.Pickup(this);

        if (m_Effect != default(Transform))
        {
            Instantiate(m_Effect, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}
