using UnityEngine;

public class KeyGet : MonoBehaviour
{
    // Reference to the KeyManager that tracks which keys the player has
    public KeyManager keyManager;

    // UI element that shows when the key is picked up (e.g., an icon)
    public GameObject yellowKeyUI;

    // Enum to define the type of key this object gives
    public enum KeyType { Yellow, Pink, Blue, Shovel }

    // Select the key type for this object in the Inspector
    public KeyType keyType = KeyType.Yellow;

    // -----------------------------------------------------------------
    // This function will be called by the Interactable script
    // when the player presses E while in range
    // -----------------------------------------------------------------
    public void CollectKey()
    {
        // Determine which key this object gives
        switch (keyType)
        {
            case KeyType.Yellow:
                // Only give the key if the player doesn't already have it
                if (!keyManager.yellowKey)
                {
                    keyManager.yellowKey = true;

                    // Show the UI icon if assigned
                    if (yellowKeyUI != null)
                    {
                        yellowKeyUI.SetActive(true);
                    }
                }
                break;

            case KeyType.Pink:
                if (!keyManager.pinkKey)
                {
                    keyManager.pinkKey = true;
                }
                break;

            case KeyType.Blue:
                if (!keyManager.blueKey)
                {
                    keyManager.blueKey = true;
                }
                break;

            case KeyType.Shovel:
                if (!keyManager.shovel)
                {
                    keyManager.shovel = true;
                }
                break;
        }

        // Remove the key object from the scene after the player collects it
        Destroy(gameObject);
    }
}
