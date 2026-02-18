using UnityEngine;
using UnityEngine.InputSystem;

public class Painting_Script : MonoBehaviour
{
    // Reference to the Rigidbody- enable physics when painting falls
    public Rigidbody rb;

    // The key that appears after the painting falls
    public GameObject yellowKey;

    // The object that will be hidden when painting falls
    public GameObject SmileyFace;

    // Animator component to play animations (currently commented out)
    public Animator animator;

    // UI element that says "Press E" when the player is in range
    public GameObject pressE_UI;

    // True when the player is inside the trigger area of the painting
    private bool playerInRange = false;

    // Prevents the interaction from being triggered more than once
    private bool hasActivated = false;


    // Runs once at the start of the game
    void Start()
    {
        // Freeze the painting in place at the start
        rb.isKinematic = true;

        // Hide the key at the beginning
        if (yellowKey != null)
        {
            yellowKey.SetActive(false);
        }

        // Hide the "Press E" UI at the beginning
        if (pressE_UI != null)
        {
            pressE_UI.SetActive(false);
        }
    }


    // Runs every frame
    void Update()
    {
        // Only check input if:
        // 1) The player is in range
        // 2) The painting has not already been activated
        // 3) The player presses the E key
        // Keyboard.current comes from the New Input System
        if (playerInRange && !hasActivated && Keyboard.current.eKey.wasPressedThisFrame)
        {
            ActivatePainting();
        }
    }


    // This function runs when the painting is activated by the player
    private void ActivatePainting()
    {
        // Mark the painting as used so it cannot be activated again
        hasActivated = true;

        // Hide the UI once the player presses E
        if (pressE_UI != null)
        {
            pressE_UI.SetActive(false);
        }

        // Play an animation using the Animator (optional)
        // Uncomment and set the Trigger name in the Animator
        // if (animator != null)
        // {
        //     animator.SetTrigger("Interact");
        // }

        // Enable physics so the painting can fall
        rb.isKinematic = false;

        // Show the key when painting falls
        if (yellowKey != null)
        {
            yellowKey.SetActive(true);
        }

        // Hide the smiley face when painting falls
        if (SmileyFace != null)
        {
            SmileyFace.SetActive(false);
        }
    }


    // Called when any collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Only respond if the player entered the trigger AND painting is not used
        if (other.CompareTag("Player") && !hasActivated)
        {
            // Allow interaction
            playerInRange = true;

            // Show the "Press E" UI
            if (pressE_UI != null)
            {
                pressE_UI.SetActive(true);
            }
        }
    }


    // Called when any collider exits the trigger collider
    private void OnTriggerExit(Collider other)
    {
        // Only respond if the player left the trigger
        if (other.CompareTag("Player"))
        {
            // Stop allowing interaction
            playerInRange = false;

            // Hide the "Press E" UI
            if (pressE_UI != null)
            {
                pressE_UI.SetActive(false);
            }
        }
    }
}