using UnityEngine;

public class UVObject : MonoBehaviour
{
    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        Hide();
    }

    public void Show()
    {
        rend.enabled = true;
    }

    public void Hide()
    {
        rend.enabled = false;
    }
}
