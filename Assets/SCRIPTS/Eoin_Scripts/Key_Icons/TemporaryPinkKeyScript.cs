using UnityEngine;
using UnityEngine.UIElements;

public class TemporaryPinkKeyScript : MonoBehaviour
{
    public Transform spawnpoint;     // Where the key will appear
    public GlobeScript globeScript;  // Reference to the globe
    public ParticleSystem spawnFX;   // Optional FX prefab to play when key spawns

    private bool hasSpawned = false; // Make sure it only spawns once

    void Update()
    {
        // Check if the globe is in the correct state and key hasn't spawned yet
        if (!hasSpawned && globeScript != null && globeScript.correct && globeScript.rotatePoint != 0f)
        {
            // Move key to spawn position
            transform.position = spawnpoint.position;

            // Play FX if assigned
            if (spawnFX != null)
            {
                ParticleSystem fxInstance = Instantiate(spawnFX, spawnpoint.position, Quaternion.identity);
                fxInstance.Play();

                // Clean up after FX duration
                Destroy(fxInstance.gameObject, fxInstance.main.duration + fxInstance.main.startLifetime.constantMax);
            }

            hasSpawned = true; // prevent repeated spawns
        }
    }
}
