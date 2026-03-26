using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Mirror_Shard_Manager : MonoBehaviour
{
    public Mirror_Shard_Collect mirrorShard1;
    public Mirror_Shard_Collect mirrorShard2;
    public Mirror_Shard_Collect mirrorShard3;
    public Mirror_Shard_Collect mirrorShard4;
    public Mirror_Shard_Collect mirrorShard5;
    public bool mirrorShard1Collected;
    public bool mirrorShard2Collected;
    public bool mirrorShard3Collected;
    public bool mirrorShard4Collected;
    public bool mirrorShard5Collected;
    public float addTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }

}
