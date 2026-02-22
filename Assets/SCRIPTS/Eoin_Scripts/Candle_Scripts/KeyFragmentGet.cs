using UnityEngine;
using System.Collections;

public class KeyFragmentGet : Interactable
{
    public KeyManager keyManager;

    protected override void Interact(GameObject player)
    {
        keyManager.fragmnetCount++;
        Debug.Log("Fragment collected");

        Destroy(gameObject);
        ShowPrompt(false);
    }
}
