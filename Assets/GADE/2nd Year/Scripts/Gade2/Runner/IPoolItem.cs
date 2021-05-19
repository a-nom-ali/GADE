﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolItem
{
    void PoolReset();
    void ReturnToPool();
}