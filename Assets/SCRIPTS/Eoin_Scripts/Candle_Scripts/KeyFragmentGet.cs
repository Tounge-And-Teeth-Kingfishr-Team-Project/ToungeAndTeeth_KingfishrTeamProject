using UnityEngine;
using UnityEngine.UIElements.Experimental;
using System.Collections;
using System.Collections.Generic;

public class KeyFragmentGet : MonoBehaviour
{
    public KeyManager keyManager;
    public Transform fragmnetSpawnPoint;
    public NewKeyFragomentSpawner theFragomentSpawner;
    public float spawnTime;
    public bool isSpawned;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (theFragomentSpawner.fragmentMove == true && theFragomentSpawner.fragmentMove != false)
        {
            StartCoroutine(DelayAction());
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            keyManager.fragmnetCount ++;
            Destroy(gameObject);
        }

    }

    public IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(spawnTime);
        transform.position = fragmnetSpawnPoint.position;
    }
}
