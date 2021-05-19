using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesPickup : Pickup
{
    public override PickupType PickupType => PickupType.Bubbles;
    public override void PoolReset()
    {
        throw new System.NotImplementedException();
    }

    public override void ReturnToPool()
    {
        throw new System.NotImplementedException();
    }
}
