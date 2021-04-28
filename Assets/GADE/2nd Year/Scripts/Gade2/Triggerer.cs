using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Triggerer : MonoBehaviour
{
    public UnityEvent TriggerEnter;
    public UnityEvent TriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if (TriggerEnter != default(UnityEvent))
            TriggerEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (TriggerExit != default(UnityEvent))
            TriggerExit.Invoke();
    }
}
