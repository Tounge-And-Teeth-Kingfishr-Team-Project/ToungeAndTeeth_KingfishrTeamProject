using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BathroomDoorInteractable : Interactable
{
    [Header("UI Settings")]
    public GameObject dialogueUI;        // UI Text or TMP object to show
    public string dialogueMessage = "You cannot enter the bathroom right now!";
    public float displayDuration = 3f;   // How long the message stays

    [Header("Player")]
    public PlayerMovement playerController; // Reference to your player movement script

    private Text dialogueText;           // Standard UI Text
    // private TMP_Text dialogueTMPText; // Uncomment if using TextMeshPro

    protected void Start()
    {

        if (dialogueUI != null)
        {
            dialogueText = dialogueUI.GetComponent<Text>();
            // dialogueTMPText = dialogueUI.GetComponent<TMP_Text>();

            dialogueUI.SetActive(false); // Hide at start
        }

        if (playerController == null)
        {
            playerController = FindFirstObjectByType<PlayerMovement>();
            if (playerController == null)
                Debug.LogWarning("PlayerController not found! Player won't be paused.");
        }
    }

    protected override void Interact(GameObject player)
    {
        // Show UI
        if (dialogueUI != null)
        {
            if (dialogueText != null) dialogueText.text = dialogueMessage;
            // if (dialogueTMPText != null) dialogueTMPText.text = dialogueMessage;

            dialogueUI.SetActive(true);
        }

        // Pause player
        if (playerController != null)
        {
            playerController.enabled = false; // disable movement script
        }

        // Start coroutine to hide UI and resume player
        StartCoroutine(HideDialogueAndResume());
        ShowPrompt(false);
    }

    private IEnumerator HideDialogueAndResume()
    {
        yield return new WaitForSeconds(displayDuration);

        if (dialogueUI != null) dialogueUI.SetActive(false);

        if (playerController != null) playerController.enabled = true;
    }
}
