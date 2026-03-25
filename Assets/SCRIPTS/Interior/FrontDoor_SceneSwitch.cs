using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class FrontDoor_SceneSwitch : Interactable
{
    [Header("Scene Settings")]
    public int sceneIndex = 4; // Scene to load

    [Header("Player")]
    public PlayerMovement playerController; // Player movement script

    [Header("UI")]
    public GameObject loadingScreen;
    public Image loadingBarFill;
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
        StartCoroutine(LoadSceneAsync());
        //SceneManager.LoadScene(sceneIndex);

        // Hide interact prompt
        ShowPrompt(false);
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBarFill.fillAmount = progressValue;
            yield return null;
        }
    }
}
