using UnityEngine;
using UnityEngine.InputSystem;

public class DoorScript : MonoBehaviour
{
    public bool doorOpen;

    // Reference to the key manager
    public KeyManager keyManager;

    // UI icon to hide when the key is used
    public GameObject yellowKeyIcon;

    // Tracks if the player is near the door
    private bool playerInRange = false;

    void Update()
    {
        // Only open door if player is in range, door not already open, and presses E
        if (playerInRange && !doorOpen && Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryOpenDoor();
        }
    }

    public void TryOpenDoor()
    {
        // Yellow key
        if (keyManager.yellowKey)
        {
            doorOpen = true;
            keyManager.yellowKey = false; // Consume the key
            transform.Rotate(0, -90, 0);  // Open the door

            // Hide the UI icon
            if (yellowKeyIcon != null)
            {
                yellowKeyIcon.SetActive(false);
            }
        }

        // Blue key
        else if (keyManager.blueKey)
        {
            doorOpen = true;
            keyManager.blueKey = false;
            transform.Rotate(0, -90, 0);
        }

        // Pink key
        else if (keyManager.pinkKey)
        {
            doorOpen = true;
            keyManager.pinkKey = false;
            transform.Rotate(0, -90, 0);
        }
    }

    // Trigger to detect player proximity
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
