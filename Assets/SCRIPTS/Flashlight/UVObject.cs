using System.Collections.Generic;
using UnityEngine;

public class UVObject : MonoBehaviour
{
    public static List<UVObject> AllUVObjects = new List<UVObject>();

    private Renderer[] renderers;

    void Awake()
    {
        // Grab ALL renderers on this object and its children
        renderers = GetComponentsInChildren<Renderer>(true);

        Hide();
    }

    void OnEnable()
    {
        if (!AllUVObjects.Contains(this))
            AllUVObjects.Add(this);
    }

    void OnDisable()
    {
        AllUVObjects.Remove(this);
    }

    public void Show()
    {
        foreach (Renderer r in renderers)
        {
            r.enabled = true;
        }
    }

    public void Hide()
    {
        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }
    }
}
