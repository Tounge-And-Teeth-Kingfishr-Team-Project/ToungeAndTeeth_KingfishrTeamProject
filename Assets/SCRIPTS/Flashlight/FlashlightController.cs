using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light normalLight;
    public Light uvLight;

    public bool IsUVMode { get; private set; }

    void Start()
    {
        SetNormalMode();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            SetUVMode();

        if (Input.GetMouseButtonDown(0))
            SetNormalMode();
    }

    void SetUVMode()
    {
        IsUVMode = true;
        normalLight.enabled = false;
        uvLight.enabled = true;
    }

    void SetNormalMode()
    {
        IsUVMode = false;

        normalLight.enabled = true;
        uvLight.enabled = false;

        UVObject[] allUV = Object.FindObjectsByType<UVObject>(FindObjectsSortMode.None);

        foreach (UVObject obj in allUV)
        {
            obj.Hide();
        }
    }

}
