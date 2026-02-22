using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorScript : Interactable
{
    [Header("Door Setup")]
    public float rotationAmount = -90f;
    public float openSpeed = 3f;
    public bool doorOpen = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    [Header("Key Requirements")]
    public bool requiresYellowKey = false;
    public bool requiresBlueKey = false;
    public bool requiresPinkKey = false;

    [Header("Key & UI References")]
    public KeyManager keyManager;
    public GameObject yellowKeyUI;
    public GameObject blueKeyUI;
    public GameObject pinkKeyUI;

    [Header("Locked Door UI")]
    public string lockedPrompt = "Door is locked";

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, rotationAmount, 0);
    }

    protected override void Interact(GameObject player)
    {
        bool canOpen = true;
        string promptText = interactPrompt;

        // Check key requirements
        if (requiresYellowKey && !keyManager.yellowKey)
        {
            canOpen = false;
            promptText = lockedPrompt;
        }
        if (requiresBlueKey && !keyManager.blueKey)
        {
            canOpen = false;
            promptText = lockedPrompt;
        }
        if (requiresPinkKey && !keyManager.pinkKey)
        {
            canOpen = false;
            promptText = lockedPrompt;
        }

        // Update UI text
        if (uiPrompt != null)
        {
            Text txt = uiPrompt.GetComponentInChildren<Text>();
            if (txt != null) txt.text = promptText;
        }

        if (!canOpen) return;

        StopAllCoroutines();
        StartCoroutine(RotateDoor(doorOpen ? closedRotation : openRotation));
        doorOpen = !doorOpen;

        // Consume keys (ONLY when opening)
        if (!doorOpen) return;

        if (requiresYellowKey && keyManager.yellowKey)
        {
            keyManager.yellowKey = false;
            if (yellowKeyUI != null) yellowKeyUI.SetActive(false);
        }
        if (requiresBlueKey && keyManager.blueKey)
        {
            keyManager.blueKey = false;
            if (blueKeyUI != null) blueKeyUI.SetActive(false);
            keyManager.fragmnetCount = 0;
        }
        if (requiresPinkKey && keyManager.pinkKey)
        {
            keyManager.pinkKey = false;
            if (pinkKeyUI != null) pinkKeyUI.SetActive(false);
        }

        ShowPrompt(false);
        Debug.Log("Door toggled: " + gameObject.name);
    }

    IEnumerator RotateDoor(Quaternion targetRotation)
    {
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * openSpeed
            );

            yield return null;
        }

        transform.rotation = targetRotation;
    }
}

