using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light normalLight;
    public Light uvLight;

    public bool IsUVMode { get; private set; }

    // UV mode is locked until player picks up lens
    public bool uvUnlocked = false;

    void Start()
    {
        // Always start in normal light mode
        SetNormalMode();

        // Make sure UV light is off initially
        uvLight.enabled = false;
    }

    void Update()
    {
        // Left click always switches to normal
        if (Input.GetMouseButtonDown(0))
        {
            SetNormalMode();
        }

        // Right click switches to UV only if UV is unlocked
        if (uvUnlocked && Input.GetMouseButtonDown(1))
        {
            SetUVMode();
        }
    }

    public void SetUVMode()
    {
        // Safety check
        if (!uvUnlocked) return;

        IsUVMode = true;
        normalLight.enabled = false;
        uvLight.enabled = true;
    }

    void SetNormalMode()
    {
        IsUVMode = false;
        normalLight.enabled = true;
        uvLight.enabled = false;

        // Hide all UV objects when switching back
        UVObject[] allUV = Object.FindObjectsByType<UVObject>(FindObjectsSortMode.None);
        foreach (UVObject obj in allUV)
        {
            obj.Hide();
        }
    }
}
