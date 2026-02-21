using UnityEngine;
using UnityEngine.UI;

public class InfoDoor : Interactable
{
    [Header("Locked Door Message")]
    public string message = "This door is locked";

    protected override void Interact(GameObject player)
    {
        // Update UI text
        if (uiPrompt != null)
        {
            Text txt = uiPrompt.GetComponentInChildren<Text>();
            if (txt != null) txt.text = message;
        }

        // Show the prompt briefly
        ShowPrompt(true);

        // Optional: hide prompt after 2 seconds
        StartCoroutine(HidePromptAfterTime(2f));

        base.Interact(player);
    }

    private System.Collections.IEnumerator HidePromptAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        ShowPrompt(false);
    }
}
