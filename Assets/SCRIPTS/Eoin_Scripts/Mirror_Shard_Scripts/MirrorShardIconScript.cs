using UnityEngine;
using UnityEngine.UI;

public class MirrorShardIconScript : MonoBehaviour
{
    public Image shard1;
    public Image shard2;
    public Image shard3;
    public Image shard4;
    public Image shard5;
    public Mirror_Shard_Manager shardManager;
    public float shardCount;
    void Start()
    {
        shard1.enabled = false;
        shard2.enabled = false;
        shard3.enabled = false;
        shard4.enabled = false;
        shard5.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shardCount == 1 && shardCount != 0) 
        {
            shard1.enabled = true;
        }
        if (shardCount == 2 && shardCount != 0)
        {
            shard2.enabled = true;
            shard1.enabled = false;
        }
        if (shardCount == 3 && shardCount != 0)
        {
            shard3.enabled = true;
            shard2.enabled = false;
        }
        if (shardCount == 4 && shardCount != 0)
        {
            shard4.enabled = true;
            shard3.enabled = false;
        }
        if (shardCount == 5 && shardCount != 0)
        {
            shard5.enabled = true;
            shard4.enabled = false;
        }
    }
}
