using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MirrorShardPlace : MonoBehaviour
{
    public MirrorShardsPickup mirrorShardManager;
    public GameObject[] shards;
    public int correct = 0;
    void Start()
    {
        foreach (var shard in shards)
        {
            shard.SetActive(false);
        }
    }
    // Update is called once per frame
    public void Place()
    {
        Debug.Log("Mirror shards placed");
        if (mirrorShardManager.mirrorShard1Collected)
        {
            shards[0].SetActive(true);
        }
        if (mirrorShardManager.mirrorShard2Collected)
        {
            shards[1].SetActive(true);
        }
        if (mirrorShardManager.mirrorShard3Collected)
        {
            shards[2].SetActive(true);
        }
        if (mirrorShardManager.mirrorShard4Collected)
        {
            shards[3].SetActive(true);
        }
        if (mirrorShardManager.mirrorShard5Collected)
        {
            shards[4].SetActive(true);
        }
        if (mirrorShardManager.mirrorShard6Collected)
        {
            shards[5].SetActive(true);
        }
        if (mirrorShardManager.mirrorShard7Collected)
        {
            shards[6].SetActive(true);
        }
        if (mirrorShardManager.mirrorShard8Collected)
        {
            shards[7].SetActive(true);
        }
        CheckCorrect();

    }
    void CheckCorrect()
    {
        correct = 0;
        for (int i = 0; i < shards.Length; i++)
        {
            if (shards[i].activeSelf)
            {
                correct++;
            }
        }
        if (correct == shards.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
