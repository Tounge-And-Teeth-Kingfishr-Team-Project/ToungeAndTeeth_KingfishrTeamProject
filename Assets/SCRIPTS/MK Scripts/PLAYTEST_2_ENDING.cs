using UnityEngine;

public class PLAYTEST_2_ENDING : MonoBehaviour
{
    public GameObject endUI;
    public MeshRenderer shard1;
    public MeshRenderer shard2;
    public MeshRenderer shard3;
    public MeshRenderer shard4;
    public MeshRenderer shard5;
    public PlayerMovement player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shard1.enabled && shard2.enabled && shard3.enabled && shard4.enabled && shard5.enabled)
        {
            endUI.SetActive(true);
            player.enabled = false;
        }
    }
}
