using System;
using UnityEngine;

public class TriggerEnterCallback : MonoBehaviour
{
    private BoxCollider theCollider;
    public bool destroyOnCollision = true;
    public event Action<TriggerEnterCallback> onEnter;
    private void Start()
    {
        theCollider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        theCollider.enabled = false;
        onEnter?.Invoke(this);
        this.enabled = !destroyOnCollision;
    }
}
