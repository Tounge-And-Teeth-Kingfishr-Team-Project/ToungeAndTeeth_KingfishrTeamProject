using UnityEngine;

public class UVLensePickup : MonoBehaviour
{
    public GameObject pressE_UI;
    public FlashlightController flashlight;

    public void PickUpLens()
    {
        if (flashlight != null)
        {
            flashlight.uvUnlocked = true; // Unlock UV mode
        }

        gameObject.SetActive(false);

        if (pressE_UI != null)
            pressE_UI.SetActive(false);
    }
}
