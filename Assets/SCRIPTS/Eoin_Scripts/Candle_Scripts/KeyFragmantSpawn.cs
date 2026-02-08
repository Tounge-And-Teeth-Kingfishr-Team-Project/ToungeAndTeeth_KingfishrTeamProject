using UnityEngine;

public class KeyFragmantSpawn : MonoBehaviour
{
    public GameObject keyFragment;
    public Transform fragmnetSpawnPoint;
    public CandleScript candleScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (candleScript.correct == true)
        {
            fragmentSpawn();
            Destroy(gameObject);
        }
    }

    private void fragmentSpawn()
    {
        GameObject fireBall;
        fireBall = Instantiate(keyFragment, fragmnetSpawnPoint.position, Quaternion.identity);
    }
}
