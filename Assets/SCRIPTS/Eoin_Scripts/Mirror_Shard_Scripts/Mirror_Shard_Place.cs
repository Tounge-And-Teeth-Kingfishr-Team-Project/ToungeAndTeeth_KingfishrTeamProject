using UnityEngine;

public class Mirror_Shard_Place : Interactable
{
    public Mirror_Shard_Manager mirrorShardManager;
    public MeshRenderer shard1;
    public MeshRenderer shard2;
    public MeshRenderer shard3;
    public MeshRenderer shard4;
    public MeshRenderer shard5;
    void Start()
    {
        shard1.enabled = false;
        shard2.enabled = false;
        shard3.enabled = false;
        shard4.enabled = false;
        shard5.enabled = false;
    }

    // Update is called once per frame
    protected override void Interact(GameObject player)
    {
        if (mirrorShardManager.mirrorShard1Collected)
        {
            shard1.enabled = true;
            mirrorShardManager.mirrorShard1Collected = false;
        }
        if (mirrorShardManager.mirrorShard2Collected)
        {
            shard2.enabled = true;
            mirrorShardManager.mirrorShard2Collected = false;
        }
        if (mirrorShardManager.mirrorShard3Collected)
        {
            shard3.enabled = true;
            mirrorShardManager.mirrorShard3Collected = false;
        }
        if (mirrorShardManager.mirrorShard4Collected)
        {
            shard4.enabled = true;
            mirrorShardManager.mirrorShard4Collected = false;
        }
        if (mirrorShardManager.mirrorShard5Collected)
        {
            shard5.enabled = true;
            mirrorShardManager.mirrorShard5Collected = false;
        }
    }
}
