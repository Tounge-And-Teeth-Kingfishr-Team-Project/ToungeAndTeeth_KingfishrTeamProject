using UnityEngine;

public class PinkKeyGet : Interactable
{
    public KeyManager keyManager;

    void Start()
    {
        // Auto-find KeyManager if not assigned
        if (keyManager == null)
            keyManager = FindFirstObjectByType<KeyManager>();
    }

    protected override void Interact(GameObject player)
    {
        if (keyManager != null && !keyManager.pinkKey)
        {
            keyManager.pinkKey = true;

            Debug.Log("Pink Key picked up!");

            // Destroy the key object
            Destroy(gameObject);
        }

        // Hide the UI prompt
        ShowPrompt(false);
    }
}
