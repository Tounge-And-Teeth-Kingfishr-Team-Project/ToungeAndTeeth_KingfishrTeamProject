using UnityEngine;
using System.Collections;

public class UVLensPickup : Interactable
{
    [Header("Player & Flashlight")]
    public GameObject playerFlashlightUV;   // Assign the UV light object on the flashlight

    [Header("UI")]
    public GameObject controlsUI;           // Controls instructions UI
    public float uiDisplayTime = 3f;        // Seconds to show the UI

    private bool uvLensCollected = false;

    private void Start()
    {
        // Ensure UV light is off at start
        if (playerFlashlightUV != null)
            playerFlashlightUV.SetActive(false);

        // Hide controls UI
        if (controlsUI != null)
            controlsUI.SetActive(false);
    }

    protected override void Interact(GameObject player)
    {
        if (uvLensCollected) return;

        uvLensCollected = true;

        // Enable the UV light
        if (playerFlashlightUV != null)
            playerFlashlightUV.SetActive(true);

        // Show controls UI
        if (controlsUI != null)
            StartCoroutine(ShowControlsUI());

        // Disable the pickup object visually
        MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
        if (mesh != null) mesh.enabled = false;

        Collider col = gameObject.GetComponent<Collider>();
        if (col != null) col.enabled = false;

        base.Interact(player);
    }

    private IEnumerator ShowControlsUI()
    {
        controlsUI.SetActive(true);
        yield return new WaitForSeconds(uiDisplayTime);
        controlsUI.SetActive(false);
    }

    public bool HasCollectedLens()
    {
        return uvLensCollected;
    }
}
