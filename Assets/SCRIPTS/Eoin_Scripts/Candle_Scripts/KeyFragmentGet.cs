using UnityEngine;
using UnityEngine.UIElements.Experimental;
using System.Collections;
using System.Collections.Generic;

public class KeyFragmentGet : MonoBehaviour
{
    public KeyManager keyManager;
    public float fragmnetCount;
    public Transform fragmnetSpawnPoint;
    public CandleScript candleScript;
    public float spawnTime;
    public bool isSpawned;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (candleScript.correct == true && candleScript.incorrect != true)
        {
            StartCoroutine(DelayAction());
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isSpawned == true)
        {
            fragmnetCount ++;
            Destroy(gameObject);
        }

    }

    public IEnumerator DelayAction()
    {
        candleScript.correct = false;
        yield return new WaitForSeconds(spawnTime);
        isSpawned = true;
        
        
    }
}
