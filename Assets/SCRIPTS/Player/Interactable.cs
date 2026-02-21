using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactRadius = 3f;
    public string interactPrompt = "Press E to interact";

    public GameObject uiPrompt; // Assign a UI element in inspector

    public bool playerInRange = false;

    // Update is called once per frame
    void Update()
    {
        // Check distance to player
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= interactRadius)
            {
                if (!playerInRange)
                {
                    playerInRange = true;
                    ShowPrompt(true);
                }

                // Press E to interact
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
                    ShowPrompt(false);
                }
            }
        }
    }

    protected virtual void Interact(GameObject player)
    {
        // This will be overridden by child classes
        Debug.Log("Interacted with " + gameObject.name);
        ShowPrompt(false);
    }

    public void ShowPrompt(bool show)
    {
        if (uiPrompt != null)
            uiPrompt.SetActive(show);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
