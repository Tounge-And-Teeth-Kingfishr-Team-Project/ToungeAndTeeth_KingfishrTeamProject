using UnityEngine;
using System.Collections;

public class UVLensePickup : MonoBehaviour
{
    public GameObject pressE_UI;
    public FlashlightController flashlight;

    // Reference to the always-active UIManager
    public UIManager uiManager;

    public float showTime = 30f;

    // This is called by the Interactable script when player presses E
    public void PickUpLens()
    {
        // Unlock UV mode
        if (flashlight != null)
            flashlight.uvUnlocked = true;

        // Hide "Press E" UI
        if (pressE_UI != null)
            pressE_UI.SetActive(false);

        // Show the UV controls through UIManager
        if (uiManager != null)
        {
            uiManager.ShowUVControls(showTime);
        }

        // Disable the lens object
        gameObject.SetActive(false);
    }
}