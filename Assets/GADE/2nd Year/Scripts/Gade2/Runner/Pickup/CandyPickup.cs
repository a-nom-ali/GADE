using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyPickup : Pickup
{
    [SerializeField] private int m_Count = 1;
    [SerializeField] private int m_HitsToBreak = 3;

    private int _hits;
    
    public override PickupType PickupType => PickupType.Candy;
    public override void PoolReset()
    {
        _hits = 0;
        gameObject.SetActive(true);
    }

    public override void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    public int Count => m_Count;

    private void OnCollisionEnter(Collision other)
    {
        _hits++;

        if (_hits == m_HitsToBreak)
            Break();
    }

    private void Break()
    {
        //spawn an effect
        ReturnToPool();
    }
}
