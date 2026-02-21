using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchInteract : Interactable
{
    [Header("Scene Settings")]
    public int sceneIndex = 0; // Scene to load

    protected override void Interact(GameObject player)
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneIndex);

        // Hide the UI prompt (optional)
        if (uiPrompt != null)
            uiPrompt.SetActive(false);

        base.Interact(player);
    }
}