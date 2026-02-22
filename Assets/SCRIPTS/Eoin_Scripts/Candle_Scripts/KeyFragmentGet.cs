using UnityEngine;
using System.Collections;

public class KeyFragmentGet : Interactable
{
    public KeyManager keyManager;
    public Transform fragmnetSpawnPoint;
    public NewKeyFragomentSpawner theFragomentSpawner;
    public float spawnTime;

    private bool isSpawned = false; // 🔥 Add this

    protected override void Interact(GameObject player)
    {
        keyManager.fragmnetCount++;
        Debug.Log("Fragment collected");

        Destroy(gameObject);
        ShowPrompt(false);
    }

    void Update()
    {
        if (theFragomentSpawner != null && theFragomentSpawner.fragmentMove && !isSpawned)
        {
            isSpawned = true;
            StartCoroutine(DelayAction());
        }
    }

    private IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(spawnTime);
        transform.position = fragmnetSpawnPoint.position;
        isSpawned = false; // allow next spawn if needed
    }
}
