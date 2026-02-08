using UnityEngine;

public class KeyFragmentGet : MonoBehaviour
{
    public KeyManager keyManager;
    public float fragmnetCount;
    public Transform fragmnetSpawnPoint;
    public CandleScript candleScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (candleScript.correct == true && candleScript.incorrect != true)
        {
            transform.position = fragmnetSpawnPoint.position;
            candleScript.correct = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fragmnetCount ++;
            Destroy(gameObject);
        }

    }
}
