using UnityEngine;

public class KeyGet : Interactable
{
    public KeyManager keyManager;
    public GameObject yellowKeyUI;

    void Start()
    {
        if (keyManager == null)
            keyManager = FindFirstObjectByType<KeyManager>();
    }

    protected override void Interact(GameObject player)
    {
        if (!keyManager.yellowKey)
        {
            keyManager.yellowKey = true;

            if (yellowKeyUI != null)
                yellowKeyUI.SetActive(true);

            Debug.Log("Yellow key picked up");

            Destroy(gameObject);
        }

        ShowPrompt(false);
    }
}
