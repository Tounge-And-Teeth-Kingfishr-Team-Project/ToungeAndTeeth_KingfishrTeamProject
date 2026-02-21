using UnityEngine;

public class HintNoteInteract : Interactable
{
    [Header("UI for the Hint Note")]
    public GameObject hintUI;             // Assign the note UI in the Inspector
    public Transform interactionPoint;    // Optional: the point from which distance is calculated

    private bool isUIOpen = false;

    private void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return;

        // Determine interaction point
        Vector3 point = interactionPoint != null ? interactionPoint.position : transform.position;
        float distance = Vector3.Distance(point, player.transform.position);

        // Handle player in range
        if (distance <= interactRadius)
        {
            if (!playerInRange)
            {
                playerInRange = true;
                ShowPrompt(true); // Show the "Press E" UI
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact(player);
            }
        }
        else
        {
            if (playerInRange)
            {
                playerInRange = false;
                ShowPrompt(false); // Hide the "Press E" UI
            }
        }

        // Close hint UI on F
        if (isUIOpen && Input.GetKeyDown(KeyCode.F))
        {
            if (hintUI != null)
            {
                hintUI.SetActive(false);
            }
            isUIOpen = false;
        }
    }

    protected override void Interact(GameObject player)
    {
        if (!playerInRange) return;

        // Show the hint UI
        if (hintUI != null && !isUIOpen)
        {
            hintUI.SetActive(true);
            isUIOpen = true;
        }

        base.Interact(player); // Optional: logs/debug
    }

    private void ShowPrompt(bool show)
    {
        if (uiPrompt != null)
        {
            uiPrompt.SetActive(show);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 point = interactionPoint != null ? interactionPoint.position : transform.position;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(point, interactRadius);
    }
}
