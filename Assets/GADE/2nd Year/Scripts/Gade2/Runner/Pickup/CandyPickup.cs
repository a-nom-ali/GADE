using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyPickup : Pickup
{
    [SerializeField] private int m_Count = 1;

    public override PickupType PickupType => PickupType.Candy;

    public int Count => m_Count;
    
}
