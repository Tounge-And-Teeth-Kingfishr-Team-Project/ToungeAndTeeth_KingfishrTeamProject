using UnityEngine;

public class UVLightReveal : MonoBehaviour
{
    public float revealRadius = 5f;
    public LayerMask uvLayer;

    private FlashlightController flashlight;

    void Start()
    {
        flashlight = GetComponentInParent<FlashlightController>();
    }

    void Update()
    {
        if (!flashlight.IsUVMode)
            return;

        RevealObjects();
    }

    void RevealObjects()
    {
        // First hide everything
        UVObject[] allUVObjects =
            Object.FindObjectsByType<UVObject>(FindObjectsSortMode.None);

        foreach (UVObject obj in allUVObjects)
        {
            obj.Hide();
        }

        // Then reveal objects inside radius
        Collider[] hits = Physics.OverlapSphere(transform.position, revealRadius, uvLayer);

        foreach (Collider hit in hits)
        {
            UVObject uvObj = hit.GetComponent<UVObject>();
            if (uvObj != null)
            {
                uvObj.Show();
            }
        }
    }
}
