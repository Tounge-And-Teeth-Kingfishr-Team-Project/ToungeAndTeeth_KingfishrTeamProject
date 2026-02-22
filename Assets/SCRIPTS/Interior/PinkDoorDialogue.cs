using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PinkDoorDialogue : MonoBehaviour
{
    [Header("Dialogue UI")]
    public GameObject dialogueUI;       // Assign the UI object
    public string dialogueMessage = "The Pink Door has been opened!";
    public float displayDuration = 3f;

    private bool hasTriggered = false;  // Ensure it only triggers once

    private Text dialogueText;          // Standard UI Text
    private TMP_Text dialogueTMPText;   // TextMeshPro

    void Start()
    {
        if (dialogueUI != null)
        {
            dialogueText = dialogueUI.GetComponent<Text>();
            dialogueTMPText = dialogueUI.GetComponent<TMP_Text>();

            dialogueUI.SetActive(false); // Hide at start
        }
        else
        {
            Debug.LogError("Dialogue UI GameObject not assigned!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            ShowDialogue();
        }
    }

    private void ShowDialogue()
    {
        if (dialogueUI == null) return;

        dialogueUI.SetActive(true);

        if (dialogueText != null)
            dialogueText.text = dialogueMessage;

        if (dialogueTMPText != null)
            dialogueTMPText.text = dialogueMessage;

        StartCoroutine(HideDialogueAfterSeconds(displayDuration));
    }

    private IEnumerator HideDialogueAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (dialogueUI != null)
            dialogueUI.SetActive(false);
    }
}
