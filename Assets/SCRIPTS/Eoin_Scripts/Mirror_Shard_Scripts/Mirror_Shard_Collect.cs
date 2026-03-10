using JetBrains.Annotations;
using UnityEngine;

public class Mirror_Shard_Collect : Interactable
{
    public bool shardCollected;
    void Start()
    {
     shardCollected = false;
    }

    protected override void Interact(GameObject player)
    {
        shardCollected = true;
        Destroy(gameObject);
    }
}
