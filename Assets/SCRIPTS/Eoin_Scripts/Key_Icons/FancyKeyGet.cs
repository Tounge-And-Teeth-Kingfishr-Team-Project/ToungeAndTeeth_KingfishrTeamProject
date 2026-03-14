using UnityEngine;

public class FancyKeyGet : Interactable
{
    public KeyManager keyManager;
    public GameObject fancykeyUI;

    void Start()
    {
        if (keyManager == null)
            keyManager = FindFirstObjectByType<KeyManager>();
    }

    protected override void Interact(GameObject player)
    {
        if (!keyManager.fancykey)
        {
            keyManager.fancykey = true;

            if (fancykeyUI != null)
                fancykeyUI.SetActive(true);

            Debug.Log("fancy key picked up");

            Destroy(gameObject);
        }

        ShowPrompt(false);
    }
}
