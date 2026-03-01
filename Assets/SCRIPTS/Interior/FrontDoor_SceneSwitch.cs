using UnityEngine;
using UnityEngine.SceneManagement;

public class FrontDoor_SceneSwitch : Interactable
{
    [Header("Scene Settings")]
    public int sceneIndex = 4; // Scene to load

    [Header("Player")]
    public PlayerMovement playerController; // Player movement script

    protected void Start()
    {
        // Auto-find player movement if not assigned
        if (playerController == null)
        {
            playerController = FindFirstObjectByType<PlayerMovement>();
            if (playerController == null)
                Debug.LogWarning("PlayerMovement not found!");
        }
    }

    protected override void Interact(GameObject player)
    {
        //// PLAYER DISABLED
        //if (playerController != null)
        //    playerController.enabled = false;

        // Load the scene
        SceneManager.LoadScene(sceneIndex);

        // Hide interact prompt
        ShowPrompt(false);
    }
}
