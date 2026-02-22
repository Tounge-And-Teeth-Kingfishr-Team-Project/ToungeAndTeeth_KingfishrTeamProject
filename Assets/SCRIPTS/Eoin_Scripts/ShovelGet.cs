using UnityEngine;

public class ShovelGet : Interactable
{
    public KeyManager keyManager;

    void Start()
    {
        // Ensure KeyManager is assigned
        if (keyManager == null)
            keyManager = FindFirstObjectByType<KeyManager>();
    }

    protected override void Interact(GameObject player)
    {
        if (keyManager != null && !keyManager.shovel)
        {
            keyManager.shovel = true;
            Debug.Log("Shovel picked up!");

            // Destroy shovel object after pickup
            Destroy(gameObject);
        }

        // Hide UI prompt after interaction
        ShowPrompt(false);
    }
}
