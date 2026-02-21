using UnityEngine;

public class KeyForFrontDoor : Interactable
{
    [Header("Door Setup")]
    public GameObject frontDoorWORKING;  // The real door to activate
    public GameObject frontDoorFAKE;     // The fake blocked door

    [Header("UI Setup")]
    public GameObject keyIcon;           // Icon to show when key is picked up

    protected override void Interact(GameObject player)
    {
        if (!playerInRange) return; // Use inherited field from Interactable

        // Disable the fake door
        if (frontDoorFAKE != null)
        {
            frontDoorFAKE.SetActive(false);
        }

        // Enable the real door
        if (frontDoorWORKING != null)
        {
            frontDoorWORKING.SetActive(true);
        }

        // Show the key icon
        if (keyIcon != null)
        {
            keyIcon.SetActive(true);
        }

        // Destroy this key object
        Destroy(gameObject);

        // Hide the UI prompt
        if (uiPrompt != null)
        {
            uiPrompt.SetActive(false);
        }

        base.Interact(player); // Optional: logs/debug
    }
}
