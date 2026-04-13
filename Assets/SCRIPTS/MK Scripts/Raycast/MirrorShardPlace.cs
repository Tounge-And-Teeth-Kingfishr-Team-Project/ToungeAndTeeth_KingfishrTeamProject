using UnityEngine;

public class MirrorShardPlace : MonoBehaviour
{
    public Mirror_Shard_Manager mirrorShardManager;
    public MeshRenderer shard1;
    public MeshRenderer shard2;
    public MeshRenderer shard3;
    public MeshRenderer shard4;
    public MeshRenderer shard5;
    public MeshRenderer shard6;
    public MeshRenderer shard7;
    public MeshRenderer shard8;
    void Start()
    {
        shard1.enabled = false;
        shard2.enabled = false;
        shard3.enabled = false;
        shard4.enabled = false;
        shard5.enabled = false;
        shard6.enabled = false;
        shard7.enabled = false;
        shard8.enabled = false;
    }

    // Update is called once per frame
    public void Place()
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
        if (mirrorShardManager.mirrorShard6Collected)
        {
            shard6.enabled = true;
            mirrorShardManager.mirrorShard6Collected = false;
        }
        if (mirrorShardManager.mirrorShard7Collected)
        {
            shard7.enabled = true;
            mirrorShardManager.mirrorShard7Collected = false;
        }
        if (mirrorShardManager.mirrorShard8Collected)
        {
            shard8.enabled = true;
            mirrorShardManager.mirrorShard8Collected = false;
        }
    }
}
