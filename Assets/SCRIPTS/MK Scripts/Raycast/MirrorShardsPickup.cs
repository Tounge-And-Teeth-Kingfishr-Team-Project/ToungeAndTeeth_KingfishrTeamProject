using TMPro;
using UnityEngine;

public class MirrorShardsPickup : MonoBehaviour
{
    public int number = 0;
    public TMP_Text counter;

    [Header("Shards")]
    public MirrorShardID mirrorShard1;
    public MirrorShardID mirrorShard2;
    public MirrorShardID mirrorShard3;
    public MirrorShardID mirrorShard4;
    public MirrorShardID mirrorShard5;
    public MirrorShardID mirrorShard6;
    public MirrorShardID mirrorShard7;
    public MirrorShardID mirrorShard8;

    [Header("Collected?")]
    public bool mirrorShard1Collected;
    public bool mirrorShard2Collected;
    public bool mirrorShard3Collected;
    public bool mirrorShard4Collected;
    public bool mirrorShard5Collected;
    public bool mirrorShard6Collected;
    public bool mirrorShard7Collected;
    public bool mirrorShard8Collected;

    // Update is called once per frame
    void Update()
    {
        counter.text = number.ToString() + "/8";

        if (mirrorShard1.shardCollected)
        {
            mirrorShard1Collected = true;
        }
        if (mirrorShard2.shardCollected)
        {
            mirrorShard2Collected = true;
        }
        if (mirrorShard3.shardCollected)
        {
            mirrorShard3Collected = true;
        }
        if (mirrorShard4.shardCollected)
        {
            mirrorShard4Collected = true;
        }
        if (mirrorShard5.shardCollected)
        {
            mirrorShard5Collected = true;
        }
        if (mirrorShard6.shardCollected)
        {
            mirrorShard6Collected = true;
        }
        if (mirrorShard7.shardCollected)
        {
            mirrorShard7Collected = true;
        }
        if (mirrorShard8.shardCollected)
        {
            mirrorShard8Collected = true;
        }
    }
}
