using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent @event;

    private void OnTriggerEnter(Collider other)
    {
        @event.Invoke();
    }
}
